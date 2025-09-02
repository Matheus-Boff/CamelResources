namespace back.DTOs
{
    public class FuncionarioCreateDTO
    {
        public int Id { get; set; }
        
        public string Matricula { get; set; }
        
        public string Nome { get; set; }
        
        public string Cargo { get; set; }
        
        public DateTime DataAdmissao { get; set; }
    }   
}