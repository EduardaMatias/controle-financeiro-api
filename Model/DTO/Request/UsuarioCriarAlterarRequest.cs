using System.ComponentModel.DataAnnotations;

namespace controle_financeiro_api.Model.DTO.Request
{
    public class UsuarioCriarAlterarRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}
