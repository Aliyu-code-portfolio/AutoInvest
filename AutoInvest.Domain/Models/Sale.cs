namespace AutoInvest.Domain.Models
{
    public class Sale:BaseEntity
    {
        public string VehicleId { get; set; }
        public string ShopId { get; set; }
        public string BuyerId { get; set; }
        public decimal Amount { get; set; }
        public bool IsSold { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public virtual User? User { get; set; }
        
    }
}
