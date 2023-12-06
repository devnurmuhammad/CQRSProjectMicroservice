namespace TurarJoy.Web.ViewModels
{
    public class HouseDTO
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public int CountFlat { get; set; }
        public DateTime BuildedAt { get; set; }
    }
}
