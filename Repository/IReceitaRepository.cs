using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Response;

namespace controle_financeiro_api.Repository
{
    public interface IReceitaRepository
    {
        Task<ReceitaDespesaResponse> Listar(int usuarioId, int mes);
        Task<bool> Criar(Receita receita);
    }
}
