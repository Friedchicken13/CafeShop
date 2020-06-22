using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models.CoffeeSelection
{ 
    public abstract class Coffee
    {
        string name;
        string size;
        decimal price;

        protected Coffee(string name, string size, decimal price)
        {
            this.name = name;
            this.size = size;
            this.price = price;
        }

        internal decimal GetPrice()
        {
            return this.price;
        }

        internal string GetSize()
        {
            return this.size;
        }

        internal string GetName()
        {
            return this.name;
        }
    }
}
