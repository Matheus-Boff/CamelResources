using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class Notebook {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NroPatrimonio { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAquisicao { get; set; }
        public string Descricao { get; set; }

    }   
}