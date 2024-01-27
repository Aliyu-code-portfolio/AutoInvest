using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace AutoInvest.Infrastructure.ExternalAPI
{
    public class PaystackHelper
    {
        public HttpClient PaystackClient { get; set; }
        public PaystackHelper(IConfiguration configuration)
        {
            string paystackSecret = configuration.GetSection("PayStack")["SecretKey"];
            PaystackClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.paystack.co/")
            };
            PaystackClient.DefaultRequestHeaders.Accept.Clear();
            PaystackClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", paystackSecret);
            PaystackClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
