namespace AutoInvest.Shared.DTO.Request
{
    public record InitializePaymentRequestDto
    {
        public string CustomerEmail { get; set; }
        public List<string> SalesIds { get; set; }
    }
}
