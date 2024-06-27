namespace TurarJoy.Domain.Entities;

public class House
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public int CountFlat { get; set; }
    public DateTime BuildedAt { get; set; }
    public ICollection<Sale>? Sales { get; set; }
}
