using Microsoft.Extensions.Configuration;
using Repository.Base;
using System;

namespace Rules.Base
{
    public class BaseRules : IDisposable
    {
        public string BaseUrl { get; private set; }

        private IConfiguration _configuration = ConfigurationConnection.ConnectionConfiguration;

        protected T GetRules<T>() where T : BaseRules
        {
            var instance = Activator.CreateInstance<T>();

            return instance;
        }

        protected T GetRepository<T>() where T : IRepository
        {
            var instance = Activator.CreateInstance<T>();
            return instance;
        }

        public virtual void Dispose()
        {

        }
    }
}
