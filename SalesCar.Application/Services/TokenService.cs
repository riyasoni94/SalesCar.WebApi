using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.PowerBI.Api.Models;
using SalesCar.Application.IServices;
using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _Key;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
        }

        /// <summary>
        /// Use to generate the JWT authorization token
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        public string CreateToken(User appUser)
        {
            try
            {
                var claims = new[] // Add Claims
            {
                  new Claim("firstname", appUser.FirstName),
                    new Claim("lastname", appUser.LastName),
                      new Claim("id", appUser.Id.ToString()),
                        new Claim("role", appUser.Role.ToString()),
                            new Claim(ClaimTypes.Email, appUser.Email),
            };
                var cred = new SigningCredentials(_Key, SecurityAlgorithms.HmacSha512Signature);

                var jwtToken = new JwtSecurityToken(
                    issuer: _configuration["Token:Issuer"],
                    audience: "localhost",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60), // Add duration of token
                    signingCredentials: cred
                    );

                return new JwtSecurityTokenHandler().WriteToken(jwtToken); //Write token
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
