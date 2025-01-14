using controle_financeiro_api.Model;

namespace controle_financeiro_api.Service
{
    public interface IHistoricoService
    {
        Task<IEnumerable<Historico>> Obter(int usuarioId);
    }
}
