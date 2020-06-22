using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models.CoffeeSelection
{
    public class NullCoffee : Coffee
    {
        public NullCoffee() : base(null, null, 0) { }
    }
}