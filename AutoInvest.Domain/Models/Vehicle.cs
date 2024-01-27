using AutoInvest.Domain.Enums;

namespace AutoInvest.Domain.Models
{
    public class Vehicle:BaseEntity
    {
        public string Name { get; set; }
        public VehicleModel Model { get; set; }
        public Condition Condition { get; set; }
        public double KilometerCovered { get; set; }
        public decimal Price { get; set; }
        public string ShopId { get; set; }
        public virtual Shop? Shop { get; set; }
        public virtual ICollection<Media>? Medias { get; set; }
    }
}
