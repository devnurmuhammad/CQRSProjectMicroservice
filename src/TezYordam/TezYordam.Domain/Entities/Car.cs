namespace TezYordam.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Number { get; set; } = default!;
        public string Model { get; set; } = default!;
        public ICollection<Call>? Calls { get; set; }
    }
}
