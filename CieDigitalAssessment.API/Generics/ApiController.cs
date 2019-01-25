
using CieDigitalAssessment.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CieDigitalAssessment.DAL
{
    // This controller is a generic WebApi controller that implements all CRUD functions based on
    // a common entity type
    [Route("api/[controller]")]
    public abstract class ApiController<T> : Controller where T : class, IEntity
    {

        // For use with response objects on create events
        protected string createdAtActionName;

        private IApplicationRepository<T> _repository;

        // DI to inject the proper repository based on type
        public ApiController(IApplicationRepository<T> repository)
        {
            _repository = repository;
        }

        public ApiController(IApplicationRepository<T> repository, string createdAtActionName = nameof(this.Find))
        {
            _repository = repository;
            this.createdAtActionName = createdAtActionName;
        }


        /// <summary>
        /// Gets all entities in the repository
        /// </summary>
        /// <returns>An IQueryable collection from the repository</returns>
        [HttpGet]
        public IActionResult Query()
        {
            return Ok(_repository.Get());
        }

        /// <summary>
        /// Gets an entity based on the id.  The id is passed in the route as per REST standards
        /// </summary>
        /// <param name="id">The id of the entity to return</param>
        /// <returns>The entity matched</returns>
        [HttpGet("{id}")]
        public IActionResult Find(int id)
        {
            var record = _repository.Get(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        /// <summary>
        /// Creates a new entity as passed in the body of the request
        /// </summary>
        /// <param name="record">A fully formed object for the entity to add</param>
        /// <returns>An object with the url to the new record and the record itself</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T record)
        {
            _repository.Create(record);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();
            
            return CreatedAtAction(createdAtActionName, new { id = record.Id }, record);
        }

        /// <summary>
        /// Updates a record based on the id and passed in entity in the body
        /// </summary>
        /// <param name="id">The id of the record as part of the route</param>
        /// <param name="record">The record itself with updated fields passed in the body</param>
        /// <returns>The updated record</returns>
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

        /// <summary>
        /// Deletes an entity based on id
        /// </summary>
        /// <param name="id">The id of the entity to be deleted</param>
        /// <returns>No content</returns>
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
