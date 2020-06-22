using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models
{
    public class ResultObject
    {
        public string user { get; set; }
        public decimal order_total { get; set; }
        public decimal payment_total { get; set; }
        public decimal balance { get; set; }
    }
}
