namespace AutoInvest.Shared.DTO.Response
{
    public  record ReviewResponseDto
    {
        public string Subject { get; init; }
        public string Comment { get; init; }
        public string ShopId { get; init; }
    }
}
