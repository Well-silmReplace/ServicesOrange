using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Rules.Sql.Usuario;
using ServicesOrange.Model.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesOrange.Controllers
{
    [ApiController]
    [Route("Api/v1/[controller]")]
    public class AuthController : BaseController
    {
        private readonly string _apiKey;

        private readonly AuthenticatedUser _user;

        public AuthController(IConfiguration configuration, AuthenticatedUser user)
        {
            //Pegando a chave da Api
            _apiKey = configuration.GetValue<string>("Api:ApiKey");

            //Setando usuário autenticado via token
            _user = user;
        }


        [HttpPost("Token")]
        [AllowAnonymous]
        public async Task<IActionResult> Token(string username, string password)
        {
            return Ok(await JResultAsync(async () =>
            {
                using (var rules = GetRules<UsuarioRules>())
                {
                    //Pegando usuário Orange
                    var user = await rules.GetUsuarioAsync(username, password);

                    //Se não achar retorna erro
                    if (user == null)
                        throw new Exception("Usuário não encontrado");

                    else if (!user.fl_SuperUser && user.nr_PerfilId != 6)
                        throw new Exception("Usuário sem permissão para consumir Api.");

                    //Retorna Token gerado
                    return await rules.GenerateToken(_apiKey, user);
                }
            }));
        }
    }
}
