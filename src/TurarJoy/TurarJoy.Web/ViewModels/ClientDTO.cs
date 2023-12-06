namespace TurarJoy.Web.ViewModels
{
    public class ClientDTO
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PassportNumber { get; set; } = default!;
        public int Age { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
