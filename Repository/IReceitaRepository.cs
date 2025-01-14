using controle_financeiro_api.Model;

namespace controle_financeiro_api.Repository
{
    public interface IReceitaRepository
    {
        Task<Receita> Obter(int usuarioId);
        Task<bool> Criar(Receita receita);
    }
}
