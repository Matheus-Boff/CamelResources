using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Alocacao {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataReserva { get; set; }

        // FK Funcionario
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario;

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