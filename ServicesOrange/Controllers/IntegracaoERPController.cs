using Microsoft.AspNetCore.Mvc;
using ServicesOrange.Model.Erp;
using ServicesOrange.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesOrange.Controllers
{
    [ApiController]
    [Route("Api/v1/[controller]")]
    public class IntegracaoERPController : BaseController
    {

        private readonly AuthenticatedUser _user;

        public IntegracaoERPController(AuthenticatedUser user)
        {
            _user = user;
        }

        [HttpGet("ArquivoLancamento")]
        public async Task<IActionResult> ArquivoLancamento()
        {
            return Ok(await JResultAsync(async () =>
            {
                //A definir parâmetros para retorno de arquivo

                return new ArquivoLancamento();
            }));
        }

        [HttpPost("LancamentoERP")]
        public async Task<IActionResult> LancamentoERP([FromBody] int idOperacaoOrange, int idOperacaoERP, int status)
        {
            return Ok(await JResultAsync(async () =>
            {
                //A definir o que vai ser feito
                return true;

            }));
        }

        [HttpPost("FaturamentoERP")]
        public async Task<IActionResult> LancamentoERP([FromBody] int idOperacaoERP, int status)
        {
            return Ok(await JResultAsync(async () =>
            {
                //A definir o que vai ser feito
                return true;

            }));
        }
    }
}
