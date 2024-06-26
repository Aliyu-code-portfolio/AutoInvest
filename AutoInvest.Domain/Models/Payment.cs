﻿namespace AutoInvest.Domain.Models
{
    public class Payment
    {
        public string Id { get; set; } 
        public string Authorization_url { get; set; }
        public string Reference { get; set; }
        public string Access_code { get; set; }
        public string SaleIds { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
    }
}
