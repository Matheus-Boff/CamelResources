namespace back.DTOs
{

    public class LaboratorioReadDTO
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public int NumComputadores { get; set; }
        
        public string Descricao { get; set; }
    }
    public class LaboratorioUpdateDTO
    {
        public string Nome { get; set; }
        public int NumComputadores { get; set; }
        public string Descricao { get; set; }
    }    
}
