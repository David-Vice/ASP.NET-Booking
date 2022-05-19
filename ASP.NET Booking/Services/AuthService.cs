using ASP.NET_Booking.Models;
using ASP.NET_Booking.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace ASP.NET_Booking.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Login(User user)
        {
            User result = await _userService.GetUserByEmail(user.Email);

            if(result.Password != user.Password)
            {
                return null;
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("!My!T0k3n!S3cr3t!K3y"));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin"),
                new Claim("Welcome", "Hello, Vice!")
            };

            JwtSecurityToken token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<User> Register(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
