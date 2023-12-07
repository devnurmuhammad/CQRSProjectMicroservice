namespace TezYordam.Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? Position { get; set; }
        public ICollection<Call>? Calls { get; set; }
    }
}
