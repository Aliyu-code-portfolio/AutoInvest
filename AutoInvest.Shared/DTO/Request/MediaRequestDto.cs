using AutoInvest.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace AutoInvest.Shared.DTO.Request
{
    public record MediaRequestDto
    {
        public IFormFile File { get; set; }
        public MediaType MediaType { get; init; }
        public string VehicleId { get; init; }
    }
}
