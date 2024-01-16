﻿using AutoInvest.Domain.Enums;

namespace AutoInvest.Domain.Models
{
    public class Vehicle
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public VehicleModel Model { get; set; }
        public Condition Condition { get; set; }
        public double KilometerCovered { get; set; }
        public decimal Price { get; set; }
        public string ShopId { get; set; }
        public virtual Shop? Shop { get; set; }
    }
}