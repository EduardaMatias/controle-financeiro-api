using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controle_financeiro_api.Model
{
    [Table("Planejamento")]
    public class Planejamento
    {
        public Planejamento() { }

        public Planejamento(int usuarioId, double valor, string mes)
        {
            this.Usuario_Id = usuarioId;
            this.Valor = valor;
            this.Mes = mes;
        }

        public void Alterar(double valor)
        {
            this.Valor = valor;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public int Usuario_Id { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public string Mes { get; set; }
    }
}
