using AutoInvest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Shared.DTO.Response
{
    public record VehicleResponseDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public VehicleModel Model { get; init; }
        public Condition Condition { get; init; }
        public double KilometerCovered { get; init; }
        public decimal Price { get; init; }
        public string ShopId { get; init; }
    }
}
