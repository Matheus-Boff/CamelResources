using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class Funcionario  {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        [Column(TypeName = "date")] 
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAdmissao { get; set; }

        public ICollection<Alocacao> Alocacoes { get; set; }
    }   
}