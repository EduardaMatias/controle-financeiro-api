using controle_financeiro_api.Model;
using controle_financeiro_api.Model.Enum;

namespace controle_financeiro_api.Service
{
    public interface IHistoricoService
    {
        Task<IEnumerable<Historico>> Listar(int usuarioId, Mes mes);
    }
}
