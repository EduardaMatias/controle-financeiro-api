using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controle_financeiro_api.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public Usuario() { }

        public Usuario(string nome, string email, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Saldo = 0;
        }

        public void AdicionarSaldo(double saldo) => Saldo += saldo;

        public void SubtrairSaldo(double saldo) => Saldo -= saldo;

        public void Alterar(string nome, string email, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public double? Saldo { get; set; }
    }
}
