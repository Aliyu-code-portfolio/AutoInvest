namespace AutoInvest.Domain.Models
{
    public class Payment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string RefNo { get; set; }
        public decimal Amount { get; set; }
    }
}
