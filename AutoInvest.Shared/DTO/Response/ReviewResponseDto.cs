namespace AutoInvest.Shared.DTO.Response
{
    public  record ReviewResponseDto
    {
        public string Id { get; set; }
        public string Subject { get; init; }
        public string Comment { get; init; }
        public string ShopId { get; init; }
    }
}
