using controle_financeiro_api.Model.DTO.Request;

namespace controle_financeiro_api.Repository
{
    public interface IAutenticacaoRepository
    {
        Task<string?> Login(AutenticacaoLoginRequest request);
    }
}
