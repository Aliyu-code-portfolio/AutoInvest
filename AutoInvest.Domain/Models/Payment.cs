namespace AutoInvest.Domain.Models
{
    public class Payment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Authorization_url { get; set; }
        public string Reference { get; set; }
        public string Access_code { get; set; }
        public string SaleIds { get; set; }
        public decimal Amount { get; set; }

    }
}
