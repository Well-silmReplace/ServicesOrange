using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Base
{
    public abstract class SqlRepository<TEntity> : IRepository where TEntity : class
    {
        private IDbConnection _connection;
        private IConfiguration _configuration = ConfigurationConnection.ConnectionConfiguration;

        public SqlRepository()
        {
            ConnectionStrings = _configuration.GetConnectionString("StringDeConexao");
        }

        private string ConnectionStrings { get; set; }

        protected IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new SqlConnection(ConnectionStrings);

                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                return _connection;
            }
        }

        public override void Dispose()
        {
            this._connection?.Close();
            this._connection?.Dispose();
            this._connection = null;

            base.Dispose();
        }
    }
}
