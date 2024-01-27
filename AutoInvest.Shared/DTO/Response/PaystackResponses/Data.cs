using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Shared.DTO.Response.PaystackResponses
{
    public class Data
    {
        public string authorization_url { get; set; }
        public string access_code { get; set; }
        public string reference { get; set; }

    }
}
