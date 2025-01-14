using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Request;

namespace controle_financeiro_api.Service
{
    public interface IDespesaService
    {
        Task<bool> Criar(DespesaCriarRequest request);
        Task<Despesa> Obter(int usuarioId);
    }
}
