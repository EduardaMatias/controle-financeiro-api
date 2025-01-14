using controle_financeiro_api.Model;

namespace controle_financeiro_api.Repository
{
    public interface IHistoricoRepository
    {
        Task<IEnumerable<Historico>> Obter(int usuarioId);
        Task<bool> Criar(Historico historico);
    }
}
