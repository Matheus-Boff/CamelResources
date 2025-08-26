public class Employee {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Registration { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public DateTime AdmissionDate { get; set; }

    public ICollection<Reservation> Reservations { get; set; }
}