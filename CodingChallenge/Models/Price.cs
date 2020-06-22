using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models
{
    public class Price
    {
        public string drink_name { get; set; }
        public Dictionary<string, decimal> prices { get; set; }

    }
}
