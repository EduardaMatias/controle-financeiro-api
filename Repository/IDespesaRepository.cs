using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Response;

namespace controle_financeiro_api.Repository
{
    public interface IDespesaRepository
    {
        Task<ReceitaDespesaResponse> Listar(int usuarioId, int mes);
        Task<bool> Criar(Despesa despesa);
    }
}
