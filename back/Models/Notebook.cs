using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Notebook {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NroPatrimonio { get; set; }
        public DateTime DataAquisicao { get; set; }
        public string Descricao { get; set; }

    }   
}