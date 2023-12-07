namespace TezYordam.Web.ViewModels
{
    public class PatientDTO
    {
        public string FirstName { get; set; } = default!;
        public string? LastName { get; set; }
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}
