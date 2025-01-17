using controle_financeiro_api.Model;

namespace controle_financeiro_api.Repository
{
    public interface IHistoricoRepository
    {
        Task<IEnumerable<Historico>> Listar(int usuarioId, int mes);
        Task<bool> Criar(Historico historico);
    }
}
