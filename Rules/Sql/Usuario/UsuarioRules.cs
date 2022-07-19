using Dominio.Entities.Usuario;
using Microsoft.IdentityModel.Tokens;
using Repository.Sql.Usuario;
using Rules.Base;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rules.Sql.Usuario
{
    public class UsuarioRules : BaseRules
    {
        public async Task<UsuarioTb> GetUsuarioAsync(string username, string password)
        {
            using (var repository = GetRepository<UsuarioRepository>())
                return await repository.GetUsuarioAsync(username, password);
        }

        public async Task<string> GenerateToken(string apiKey, UsuarioTb user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(apiKey);

            //Definindo claims de usuário e regras do Token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                            new Claim(ClaimTypes.Sid, user.Id.ToString()),
                            new Claim(ClaimTypes.UserData, user.tx_Username),
                            new Claim(ClaimTypes.Name, user.tx_Nome),
                            new Claim(ClaimTypes.Email, user.tx_Email),
                            new Claim(ClaimTypes.AuthorizationDecision, user.fl_SuperUser ? "admin" : "user")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            //Gerando Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
