using controle_financeiro_api.Model;

namespace controle_financeiro_api.Repository
{
    public interface IDespesaRepository
    {
        Task<Despesa> Obter(int usuarioId);
        Task<bool> Criar(Despesa despesa);
    }
}
