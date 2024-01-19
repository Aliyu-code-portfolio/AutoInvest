namespace AutoInvest.Domain.Models
{
    public class Review:BaseEntity
    {
        public string Subject { get; set; }
        public bool CarPurchased { get; set; }
        public string Comment { get; set; }
    }
}
