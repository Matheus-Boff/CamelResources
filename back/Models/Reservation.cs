public class Reservation {
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }

    // Employee foreign key
    public int EmployeeId { get; set; }
    public Employee Employee;

    // Notebook foreign key
    public int? NotebookId { get; set; }
    public Notebook? Notebook { get; set; }

    // Class foreign key
    public int? ClassId { get; set; }
    public Class? Class { get; set; }

    // Laboratory foreign key
    public int? LaboratoryId { get; set; }
    public Laboratory? Laboratory { get; set; }
}