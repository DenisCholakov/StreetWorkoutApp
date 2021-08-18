using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StreetWorkoutApp.Data;
using StreetWorkoutApp.Data.Models;

using userRoleConstants = StreetWorkoutApp.Data.Models.UserRoles;

namespace StreetWorkoutApp.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly StreetWorkoutDbContext data;

        public IdentityService(StreetWorkoutDbContext data)
        {
            this.data = data;
        }

        public string GenerateJwtToken(string userId, string userName, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }

        public string GetLoggedUserId()
        {
            throw new NotImplementedException();
        }
    }
}
