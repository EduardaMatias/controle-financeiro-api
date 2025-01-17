using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Response;
using controle_financeiro_api.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace controle_financeiro_api.Repository
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly string _connectionString;

        public DespesaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ReceitaDespesaResponse> Listar(int usuarioId, int mes)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string totalDespesas = @"SELECT SUM(D.Valor)
                                FROM Despesa D
                                WHERE D.Usuario_Id = @UsuarioId
                                AND MONTH(D.Data) = @Mes";

            var total = await conn.QueryFirstOrDefaultAsync<decimal>(totalDespesas, new { UsuarioId = usuarioId, Mes = mes });

            string despesas = @"SELECT D.Id, D.Usuario_Id, D.Valor, D.Moeda, D.Data, D.Categoria
                                FROM Despesa D
                                WHERE D.Usuario_Id = @UsuarioId
                                AND MONTH(D.Data) = @Mes";

            var itens = await conn.QueryAsync<ReceitaDespesaItemResponse>(despesas, new { UsuarioId = usuarioId, Mes = mes });

            return new ReceitaDespesaResponse
            {
                Total = (int)total,
                Itens = itens
            };
        }

        public async Task<bool> Criar(Despesa despesa)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using IDbTransaction tran = connection.BeginTransaction();
            await connection.InsertAsync(despesa, tran);
            tran.Commit();
            return true;
        }
    }
}
