using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CieDigitalAssessment.API.Models;
using CieDigitalAssessment.DAL;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System;

namespace CieDigitalAssessment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ApiController<User>
    {
        IApplicationRepository<User> _repository;

        public UsersController(IApplicationRepository<User> repository) : base(repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var users = _repository.Get();

            // TODO Encrypt the password on register and verify it here using BCrypt
            var user = users.SingleOrDefault(x => x.Username == userParam.Username && x.PasswordHash == userParam.PasswordHash);

            // return null if user not found
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("superSuperSecretKey");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.PasswordHash = null;

            

            return Ok(user);
        }
    }
}