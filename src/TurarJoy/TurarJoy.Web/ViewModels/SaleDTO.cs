namespace TurarJoy.Web.ViewModels
{
    public class SaleDTO
    {
        public DateTime SaledAt { get; set; }
        public string? Cost { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public int HouseId { get; set; }
    }
}
