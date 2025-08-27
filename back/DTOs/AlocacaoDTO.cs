namespace back.DTOs
{

    public class AlocacaoReadDTO
    {
        public int Id { get; set; }
        
        public DateTime DataAlocacao { get; set; }
        
        public int FuncionarioId { get; set; }
        
        public int? NotebookId { get; set; }
        
        public int? SalaId { get; set; }
        
        public int? LaboratorioId { get; set; }
    }
    public class AlocacaoCreateDTO
    {
        public DateTime DataAlocacao { get; set; }
        
        public int FuncionarioId { get; set; }
        
        public int? NotebookId { get; set; }
        
        public int? SalaId { get; set; }
        
        public int? LaboratorioId { get; set; }
    }   
}