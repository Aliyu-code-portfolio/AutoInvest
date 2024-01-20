using AutoInvest.Domain.Enums;

namespace AutoInvest.Shared.DTO.Response
{
    public record MediaResponseDto
    {
        public string Id { get; init; }
        public string Url { get; init; }
        public MediaType MediaType { get; init; }
        public string VehicleId { get; init; }
    }
}
