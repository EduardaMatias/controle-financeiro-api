using System.ComponentModel.DataAnnotations;

namespace controle_financeiro_api.Model.DTO.Request
{
    public class UsuarioAdicionarSaldoRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Saldo { get; set; }
    }
}

