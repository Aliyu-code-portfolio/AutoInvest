﻿namespace AutoInvest.Domain.Models
{
    public class Shop:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CompanyName { get; set; }
        public string RCNumber { get; set; }
        public bool IsVerified { get; set; }
        public virtual ICollection<Review>? Reviews{ get; set; } 
        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}
