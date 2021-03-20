using ApplicationAuthentication.Abstraction;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAuthentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key = default;
        public IUserRepository _userRepository = default;
        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }


        public async Task<string> AuthenticateAsync(UserAuthDto data)
        {
            var user = await _userRepository.SignInAsync(data);
            if (user == false) { return null; }

            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,data.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void SetUserRepo(IUserRepository usersRepo)
        {
            _userRepository = usersRepo;
        }
    }
}
