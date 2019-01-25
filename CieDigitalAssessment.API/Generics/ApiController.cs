
using CieDigitalAssessment.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CieDigitalAssessment.DAL
{
    
    [Route("api/[controller]")]
    public abstract class ApiController<T> : Controller where T : class, IEntity
    {
        protected string createdAtActionName;

        private IApplicationRepository<T> _repository;

        public ApiController(IApplicationRepository<T> repository)
        {
            _repository = repository;
        }

        public ApiController(IApplicationRepository<T> repository, string createdAtActionName = nameof(this.Find))
        {
            _repository = repository;
            this.createdAtActionName = createdAtActionName;
        }


        [HttpGet]
        public IActionResult Query()
        {
            return Ok(_repository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Find(int id)
        {
            var record = _repository.Get(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T record)
        {
            _repository.Create(record);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();
            
            return CreatedAtAction(createdAtActionName, new { id = record.Id }, record);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] T record)
        {
            if (id != record.Id)
                return BadRequest();

            _repository.Update(record);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return Ok(record);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _repository.Delete(id);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return NoContent();
        }
    }
}
