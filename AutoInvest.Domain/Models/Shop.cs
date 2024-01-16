namespace AutoInvest.Domain.Models
{
    public class Shop
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CompanyName { get; set; }
        public string RCNumber { get; set; }
        public bool IsVerified { get; set; }
        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}
