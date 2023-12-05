namespace TurarJoy.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public ICollection<Sale>? Sales { get; set; }
}
