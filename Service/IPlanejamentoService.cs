using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model.Enum;

namespace controle_financeiro_api.Service
{
    public interface IPlanejamentoService
    {
        Task<bool> Criar(PlanejamentoCriarRequest request);
        Task<Planejamento> Obter(int usuarioId, string mes);
        Task<bool> Alterar(int id, PlanejamentoAlterarRequest request);
    }
}
