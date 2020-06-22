using CodingChallenge.Models.CoffeeSelection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models
{
    public interface IBeverageFactory
    {
        List<Coffee> CreateCoffees(List<Price> priceList);       
    }
}
