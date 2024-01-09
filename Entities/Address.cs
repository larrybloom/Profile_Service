namespace ProfileService.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}
