public class Laboratory {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public int ComputersNum { get; set; }
    public string ComputersConfig { get; set; }
}