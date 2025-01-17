using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Response;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace controle_financeiro_api.Repository
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly string _connectionString;

        public ReceitaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ReceitaDespesaResponse> Listar(int usuarioId, int mes)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string totalReceitas = @"SELECT SUM(R.Valor)
                                FROM Receita R
                                WHERE R.Usuario_Id = @UsuarioId
                                AND MONTH(R.Data) = @Mes";

            var total = await conn.QueryFirstOrDefaultAsync<decimal>(totalReceitas, new { UsuarioId = usuarioId, Mes = mes });

            string receitas = @"SELECT R.Id, R.Usuario_Id, R.Valor, R.Moeda, R.Data, R.Categoria
                                FROM Receita R
                                WHERE R.Usuario_Id = @UsuarioId
                                AND MONTH(R.Data) = @Mes";

            var itens = await conn.QueryAsync<ReceitaDespesaItemResponse>(receitas, new { UsuarioId = usuarioId, Mes = mes });

            return new ReceitaDespesaResponse
            {
                Total = (int)total, 
                Itens = itens
            };
        }

        public async Task<bool> Criar(Receita receita)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using IDbTransaction tran = connection.BeginTransaction();
            await connection.InsertAsync(receita, tran);
            tran.Commit();
            return true;
        }
    }
}
