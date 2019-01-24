using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CieDigitalAssessment.API;
using CieDigitalAssessment.API.Models;
using CieDigitalAssessment.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace CieDigitalAssessment
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {

        private IApplicationRepository<User> _repository;

        public UserService(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }
        

        public User Authenticate(string username, string password)
        {
            var users = _repository.Get();
            var user = users.SingleOrDefault(x => x.Username == username);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
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

            return user;
        }

     
    }
}