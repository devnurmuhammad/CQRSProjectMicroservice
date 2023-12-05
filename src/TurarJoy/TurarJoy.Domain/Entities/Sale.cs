using System.ComponentModel.DataAnnotations.Schema;

namespace TurarJoy.Domain.Entities;

public class Sale
{
    public int Id { get; set; }
    public DateTime SaledAt { get; set; }
    public string? Cost { get; set; }

    [ForeignKey("EmployeeId")]
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    [ForeignKey("ClienId")]
    public int ClienId { get; set; }
    public Client? Client { get; set; }

    [ForeignKey("HouseId")]
    public House? House { get; set; }
    public int HouseId { get; set; }
}
