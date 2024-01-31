using AutoInvest.Domain.Enums;

namespace AutoInvest.Shared.DTO.Response
{
    public record SalesResponseDto
    {
        public string Id { get; init; }
        public string VehicleId { get; init; }
        public string ShopId { get; init; }
        public VehicleModel VehicleModel { get; init; }
        public decimal Amount { get; set; }
        public bool IsSold { get; set; }
        public Condition Condition { get; init; }
    }
}
