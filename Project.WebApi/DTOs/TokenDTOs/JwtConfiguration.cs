using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.DTOs
{
    public class JwtConfiguration 
    {
        private readonly JwtOptions jwtOptions;


        public JwtConfiguration(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions.Value;
        }

        public string Generate(AppUser user)
        {

            var claims = new Claim[] 
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.secureKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                jwtOptions.Issuer,
                jwtOptions.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(1),
                credentials
                );

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            //var header = new JwtHeader(credentials);

            //var payload = new JwtPayload(id, null, claims, null, DateTime.Today.AddDays(1));
            //var securityToken = new JwtSecurityToken(header, payload);

            return tokenValue;
        }


    }
}
