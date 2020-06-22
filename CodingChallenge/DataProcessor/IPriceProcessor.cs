using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.DataProcessor
{
    public interface IPriceProcessor
    {
        List<Coffee> ProcessInputPrice();
    }
}
