using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoApp.Core.Services;

namespace ToDoApp.Service.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _config;

        public JWTService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJSONWebToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exprationDateTime = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(_config["Jwt:ValidIssuer"],
                                             _config["Jwt:ValidAudience"],
                                             claims,
                                             expires: exprationDateTime,
                                             signingCredentials: credentials);

            var JWTToken = new JwtSecurityTokenHandler().WriteToken(token);

            return JWTToken;
        }
    }
}