using AutoInvest.Domain.Enums;

namespace AutoInvest.Shared.DTO.Response
{
    public record SalesResponseDto
    {
        public string VehicleId { get; init; }
        public string ShopId { get; init; }
        public VehicleModel VehicleModel { get; init; }
        public Condition Condition { get; init; }
    }
}
