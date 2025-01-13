using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controle_financeiro_api.Model
{
    [Table("Historico")]
    public class Historico
    {
        public Historico() { }

        public Historico(int usuarioId, string tipo, double valor, DateOnly data)
        {
            this.Usuario_Id = usuarioId;
            this.Tipo = tipo;
            this.Valor = valor;
            this.Data = data;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public int Usuario_Id { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateOnly Data { get; set; }
    }
}
