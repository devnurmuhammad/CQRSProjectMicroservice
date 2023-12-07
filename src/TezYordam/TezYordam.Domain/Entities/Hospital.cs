namespace TezYordam.Domain.Entities
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string? Email { get; set; }
        public string Address { get; set; } = default!;
    }
}
