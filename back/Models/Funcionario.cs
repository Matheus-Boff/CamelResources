using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Funcionario {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }

        public ICollection<Alocacao> Alocacoes { get; set; }
    }   
}