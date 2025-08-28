using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.Models.Enums;

namespace back.Models
{
    public class Alocacao {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")] 
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAlocacao { get; set; }
        
        public ResourceType ResourceType { get; set; }

        // FK Funcionario
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        // FK Notebook
        public int? NotebookId { get; set; }
        public Notebook? Notebook { get; set; }

        // FK Sala
        public int? SalaId { get; set; }
        public Sala? Sala { get; set; }

        // FK Laboratorio
        public int? LaboratorioId { get; set; }
        public Laboratorio? Laboratorio { get; set; }
        
        
    }   
}