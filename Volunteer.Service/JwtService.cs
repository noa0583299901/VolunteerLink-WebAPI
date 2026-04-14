using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;

namespace Volunteer.Service
{
    public class JwtService(IConfiguration configuration)
    {
        public string GenerateToken(MyVolunteer volunteer)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, volunteer.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{volunteer.FirstName} {volunteer.LastName}"),
                new Claim(ClaimTypes.Email, volunteer.Email),
                new Claim(ClaimTypes.Role, volunteer.Role ?? "User")
            };

            var secretKey = configuration["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(double.Parse(configuration["Jwt:ExpiresHours"])),
                signingCredentials: creds,
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"]);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}