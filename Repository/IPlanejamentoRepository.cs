using controle_financeiro_api.Model;

namespace controle_financeiro_api.Repository
{
    public interface IPlanejamentoRepository
    {
        Task<bool> Criar(Planejamento planejamento);
        Task<bool> Alterar(Planejamento planejamento);
        Task<Planejamento> Obter(int id);
        Task<Planejamento?> Obter(int usuarioId, string mes);
    }
}
