namespace back.DTOs
{

    public class SalaReadDTO
    {
        public int Id { get; set; }
        
        public int Numero { get; set; }
        
        public int NumLugares { get; set; }
        
        public bool Projetor { get; set; }
    }
    public class SalaUpdateDTO
    {
        public int Numero { get; set; }
        public int NumLugares { get; set; }
        public bool Projetor { get; set; }
    }
}