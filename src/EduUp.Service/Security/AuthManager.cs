﻿using EduUp.Domain.Entities.Users;
using EduUp.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Security
{
    public class AuthManager : IAuthManager
    {
        private readonly IConfiguration _config;

        public AuthManager(IConfiguration configuration)
        {
            _config = configuration.GetSection("Jwt");
        }
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
            new Claim("Id", user.Id.ToString()),
            new Claim("FullName", user.FullName),
            new Claim("Email", user.Email),

        };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
                expires: DateTime.Now.AddDays(int.Parse(_config["Lifetime"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }

    }
}
