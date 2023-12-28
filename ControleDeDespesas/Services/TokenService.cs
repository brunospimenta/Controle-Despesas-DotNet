using ControleDeDespesas.Models;
using ControleDeDespesas.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleDeDespesas.Services
{
    public class TokenService
    {
        //private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            //_configuration = configuration;
        }

        public string GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("id", usuario.Id.ToString()),
                new Claim("username", usuario.UserName),
                new Claim(ClaimTypes.Role, usuario.RoleId.ToString()),
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bdqwydbuwqdywqb214421duqwybd2134124124qwuy"));

            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(2),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}