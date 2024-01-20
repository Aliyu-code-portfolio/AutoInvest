using AutoInvest.Domain.Enums;

namespace AutoInvest.Shared.DTO.Request
{
    public record VehicleRequestDto
    {
        public string Name { get; init; }
        public VehicleModel Model { get; init; }
        public Condition Condition { get; init; }
        public double KilometerCovered { get; init; }
        public decimal Price { get; init; }
        public string ShopId { get; init; }
    }
}
