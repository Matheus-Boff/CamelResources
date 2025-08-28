using System.ComponentModel.DataAnnotations;

namespace back.DTOs
{
    public class NotebookCreateDTO
    {
        [Required]
        public string NroPatrimonio { get; set; }
        public DateTime DataAquisicao { get; set; }
        public string Descricao { get; set; }
    }

    public class NotebookUpdateDTO
    {
        public string NroPatrimonio { get; set; }
        public DateTime DataAquisicao { get; set; }
        public string Descricao { get; set; }
    }

    public class NotebookReadDTO
    {
        public int Id { get; set; }
        public string NroPatrimonio { get; set; }
        public DateTime DataAquisicao { get; set; }
        public string Descricao { get; set; }
    }    
}

