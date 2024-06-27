namespace TezYordam.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string? LastName { get; set; }
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public ICollection<Call>? Calls { get; set; }
    }
}
