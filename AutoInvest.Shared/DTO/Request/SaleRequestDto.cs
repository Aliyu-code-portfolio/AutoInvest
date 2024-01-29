using AutoInvest.Domain.Enums;

namespace AutoInvest.Shared.DTO.Request
{
    public record SaleRequestDto
    {
        public string VehicleId { get; init; }
        public string BuyerId { get; init; } // I felt this should be a part of the request dto so as to 
                                            // who the buyer is and see if he or she is a registered user.
    }
}
