using AutoInvest.Domain.Enums;

namespace AutoInvest.Domain.Models
{
    public class Media:BaseEntity
    {
        public string Url { get; set; }
        public MediaType MediaType { get; set; }
    }
}
