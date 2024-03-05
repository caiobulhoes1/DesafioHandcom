using Blazored.LocalStorage;
using DesafioHandcom.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioHandcom.Server.Service
{
    public class JwtService
    {
        private readonly ILocalStorageService _localstorage;
        private readonly AppDbContext _dataContext;

        public JwtService(ILocalStorageService localstorage, AppDbContext dataContext)
        {
            _dataContext = dataContext;
            _localstorage = localstorage;
        }

        public string Create(UserModel usuario)
        {
			var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.Configuration.PrivateKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(usuario),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(3)
            };

            var token = handler.CreateToken(tokenDescriptor);
            var tokenString = handler.WriteToken(token);

            _localstorage.SetItemAsStringAsync("token", token.ToString());
            return tokenString;
        }

        public static ClaimsIdentity GenerateClaims(UserModel usuario)
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim(ClaimTypes.Name, usuario.Name));
            ci.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));
            ci.AddClaim(new Claim("Id", usuario.Id.ToString()));

            return ci;
        }
    }
}
