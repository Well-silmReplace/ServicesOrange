using Microsoft.AspNetCore.Mvc;
using Rules.Base;
using System;
using System.Threading.Tasks;

namespace ServicesOrange.Controllers
{
    public class BaseController : ControllerBase
    {
        #region Protected methods

        [NonAction]
        protected T GetRules<T>() where T : BaseRules
        {
            var instance = Activator.CreateInstance<T>();

            return instance;
        }

        async protected Task<object> JResultAsync<T>(Func<Task<T>> acao)
        {
            try
            {
                var data = await acao();

                var objectResult = new { data };

                return objectResult;
            }

            catch (Exception e)
            {
                return new { e.Message };
            }
        }

        #endregion
    }
}
