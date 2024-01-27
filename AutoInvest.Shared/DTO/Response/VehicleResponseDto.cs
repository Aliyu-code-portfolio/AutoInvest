using AutoInvest.Domain.Enums;

namespace AutoInvest.Shared.DTO.Response
{
    public record VehicleResponseDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public VehicleModel Model { get; init; }
        public Condition Condition { get; init; }
        public double KilometerCovered { get; init; }
        public decimal Price { get; init; }
        public string ShopId { get; init; }
        public virtual ICollection<MediaResponseDto>? Medias { get; init; }
    }
}
