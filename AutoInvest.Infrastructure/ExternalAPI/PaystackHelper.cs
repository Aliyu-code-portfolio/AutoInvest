using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Infrastructure.ExternalAPI
{
    public class PaystackHelper
    {
        public HttpClient PaystackClient { get; set; }
       /* public PaystackHelper(IConfiguration configuration)
        {
            string paystackSecret = configuration.GetSection("PayStackKey");
            PaystackClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.paystack.co/")
            };
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", paystackSecret);
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }*/
    }
}
