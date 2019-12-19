using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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

            //if (!IsValidUser(request.Username, request.Password)) return false;

            using (var _db = new avtokampiContext())
            {
                var user = _db.Uporabniki.Where(o => o.Email == request.Username).SingleOrDefault();
                if (user == null) return false;

                var claim = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, request.Username),
                    new Claim(ClaimTypes.Role, "Admin"/*_db.Pravice.Where(o => o.PravicaId == user.UporabnikId).Select(o => o.Naziv).FirstOrDefault()*/)
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
        }

        public bool IsRegister(RegisterModel user)
        {
            if(user != null && !string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Geslo))
            {
                using var sha2 = new SHA256CryptoServiceProvider();
                var data = Encoding.UTF8.GetBytes(user.Geslo);
                var passwd = sha2.ComputeHash(data);
                var hashedpasswd = BitConverter.ToString(passwd).Replace("-", "").ToLower();

                using var _db = new avtokampiContext();
                user.Geslo = hashedpasswd;
                _db.Uporabniki.Add(new Uporabniki() { 
                    Ime = user.Ime,
                    Priimek = user.Priimek,
                    Telefon = user.Telefon ?? null,
                    Email = user.Email,
                    Geslo = hashedpasswd,
                    Pravice = 1
                });
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool IsValidUser(string username, string password)
        {
            using (var _db = new avtokampiContext())
            {
                if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                {
                    var user = _db.Uporabniki.Where(o => o.Email == username).SingleOrDefault();

                    using var sha2 = new SHA256CryptoServiceProvider();
                    var data = Encoding.UTF8.GetBytes(password);
                    var passwd = sha2.ComputeHash(data);
                    var hashedpasswd = BitConverter.ToString(passwd).Replace("-", "").ToLower();


                    if (user != null && user.Geslo == hashedpasswd)
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
