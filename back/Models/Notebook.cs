public class Notebook {
    [Key]
    public int Id { get; set; }

    [Required]
    public string PatrimonyNumber { get; set; }
    public DateTime AcquisitionDate { get; set; }
    public string Description { get; set; }

}