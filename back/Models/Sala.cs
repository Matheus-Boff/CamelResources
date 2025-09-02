
using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Sala {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public int NumLugares { get; set; }
        public bool Projetor { get; set; }
    }   
}