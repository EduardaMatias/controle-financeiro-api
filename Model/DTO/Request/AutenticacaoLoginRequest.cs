using System.ComponentModel.DataAnnotations;

namespace controle_financeiro_api.Model.DTO.Request
{
    public class AutenticacaoLoginRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}
