using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AvtokampiWebAPI.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TokenManagement _tokenManagement;

        public AuthRepository(IOptions<TokenManagement> tokenManagement)
        {
            _tokenManagement = tokenManagement.Value;
        }

        public bool IsAuthenticated(TokenModel request, out string token)
        {
            token = string.Empty;

            if (!IsValidUser(request.Username, request.Password)) return false;

            string zaposleni = null;
            if (zaposleni == null) return false;

            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.Role, "Administrator")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claim,
                expires: DateTime.Now.AddDays(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }

        public bool IsRegister(Uporabniki user)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUser(string username, string password)
        {
            using (var _db = new avtokampiContext())
            {
                if(!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                {
                    var user = _db.Uporabniki.Where(o => o.Email == username).FirstOrDefault();
                    if(user != null && user.Geslo == password)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }
    }
}
