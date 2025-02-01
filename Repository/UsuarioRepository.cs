using controle_financeiro_api.Models;
using Dapper;
using System.Data;
using Npgsql;

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
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"SELECT * FROM ""Usuario"" WHERE ""Id"" = @Id";
            return await conn.QueryFirstOrDefaultAsync<Usuario>(query, new { Id = id });
        }

        public async Task<Usuario> Obter(string email)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"SELECT * FROM ""Usuario"" WHERE ""Email"" = @Email";
            return await conn.QueryFirstOrDefaultAsync<Usuario>(query, new { Email = email });
        }

        public async Task<bool> Criar(Usuario usuario)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            string query = @"INSERT INTO ""Usuario"" (""Nome"", ""Email"", ""Senha"", ""Saldo"") 
                                    VALUES (@Nome, @Email, @Senha, @Saldo)";

            using IDbTransaction tran = conn.BeginTransaction();
            int rowsAffected = await conn.ExecuteAsync(query, usuario, tran);
            tran.Commit();

            return rowsAffected > 0;
        }


        public async Task<bool> Alterar(Usuario usuario)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            const string query = @"UPDATE ""Usuario"" 
                                    SET ""Nome"" = @Nome, 
                                    ""Email"" = @Email, 
                                    ""Senha"" = @Senha, 
                                    ""Saldo"" = @Saldo
                                    WHERE ""Id"" = @Id";

            using IDbTransaction tran = conn.BeginTransaction();
            int rowsAffected = await conn.ExecuteAsync(query, usuario, tran);
            tran.Commit();

            return rowsAffected > 0;
        }

    }
}
