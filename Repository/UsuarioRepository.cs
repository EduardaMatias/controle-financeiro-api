using controle_financeiro_api.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace controle_financeiro_api.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Usuario> Obter(int id)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return await conn.GetAsync<Usuario>(id);
        }

        public async Task<Usuario> Obter(string email)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT * FROM Usuario WHERE Email = @Email";
            return await conn.QueryFirstOrDefaultAsync<Usuario>(query, new { Email = email });
        }

        public async Task<bool> Criar(Usuario usuario)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            using IDbTransaction tran = connection.BeginTransaction();
            await connection.InsertAsync(usuario, tran);
            tran.Commit();
            return true;
        }

        public async Task<bool> Alterar(Usuario usuario)
        {
            using IDbConnection connectionDapper = new SqlConnection(_connectionString);
            connectionDapper.Open();

            using IDbTransaction tran = connectionDapper.BeginTransaction();
            await connectionDapper.UpdateAsync(usuario, tran);
            tran.Commit();
            return true;
        }

    }
}
