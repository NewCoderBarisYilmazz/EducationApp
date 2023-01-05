using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Security
{
    public class JwtHandler : IJwtHandler
    {
        public string CreateToken()
        {

            var claims = new Claim[]
            {
                new Claim (JwtRegisteredClaimNames.Sub,"baris"),
                new Claim(JwtRegisteredClaimNames.Email,"www.baris"),
                new Claim(JwtRegisteredClaimNames.Website,"baris@deneem")
            };
            JwtSecurityToken jwtSecurityToken = new
                (

                issuer: "baris",
                audience: "www.baris",
                claims: null,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("deneme")), SecurityAlgorithms.HmacSha512));
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

               
            return token;

        }

    }
}
