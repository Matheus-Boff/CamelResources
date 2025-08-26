using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Laboratorio {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public int NumComputadores { get; set; }
        public string Descricao { get; set; }
    }   
}