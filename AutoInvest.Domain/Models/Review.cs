namespace AutoInvest.Domain.Models
{
    public class Review
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Subject { get; set; }
        public DateTime DateUploaded { get; set; }
        public bool IPurchasedThisCar { get; set; }
        public string Comment { get; set; }
    }
}
