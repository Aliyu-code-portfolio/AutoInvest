using AutoInvest.Domain.Enums;

namespace AutoInvest.Shared.DTO.Request
{
    public record AddressRequestDto
    {
        public string HouseNumber { get; init; }
        public string StreetName { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        //public UserType UserType { get; init; }
    }
}

//I don't know if it is okay to create a response dto, i could not predict where it will be needed.
