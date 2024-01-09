namespace ProfileService.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public DateTime DateGenerated { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Token { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
