namespace AutoInvest.Shared.DTO.Response
{
    public record ShopResponseDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string CompanyName { get; set; }
    }
}
