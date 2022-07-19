using Dominio.Entities.Usuario;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Dominio.Helpers;
using System.Security.Cryptography;
using System.Linq;

namespace Repository.Sql.Usuario
{
    public class UsuarioRepository : SqlRepository<UsuarioTb>
    {
        public async Task<UsuarioTb> GetUsuarioAsync(string username, string password)
        {
            var p = new DynamicParameters();

            p.Add("username", username, DbType.String, ParameterDirection.Input);
            p.Add("password", password.GetMd5Hash(MD5.Create()), DbType.String, ParameterDirection.Input);

            string sql = @"select * from System.Usuario where tx_Username = @username and tx_Senha = @password";

            return (await Connection.QueryAsync<UsuarioTb>(sql, p, commandType: CommandType.Text)).FirstOrDefault();
        }
    }
}
