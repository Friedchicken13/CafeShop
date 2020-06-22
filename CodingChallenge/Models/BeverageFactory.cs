using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models
{
    public class BeverageFactory : IBeverageFactory
    {
        public List<Coffee> CreateCoffees(List<Price> priceList)
        {
            List<Coffee> coffeeList = new List<Coffee>();
            if (priceList != null)
            {
                foreach (var price in priceList)
                {
                    foreach (var size in price.prices)
                    {
                        coffeeList.Add(CreateCoffeeTypeByName(price.drink_name, size.Key, size.Value));
                    }
                }
            }
            return coffeeList;
        }


        private static Coffee CreateCoffeeTypeByName(string drinkName,string size,decimal price)
        {
            if (drinkName.ToLower().Equals(CoffeeType.ShortEspresso.Name)) return new ShortEspresso(drinkName,size,price);
            else if (drinkName.ToLower().Equals(CoffeeType.Latte.Name)) return new Latte(drinkName, size, price);
            else if (drinkName.ToLower().Equals(CoffeeType.FlatWhite.Name)) return new FlatWhite(drinkName, size, price);
            else if (drinkName.ToLower().Equals(CoffeeType.LongBlack.Name)) return new LongBlack(drinkName, size, price);
            else if (drinkName.ToLower().Equals(CoffeeType.Mocha.Name)) return new Mocha(drinkName, size, price);
            else if (drinkName.ToLower().Equals(CoffeeType.SuperMochacrapuCaramelCream.Name)) return new SuperMochacrapuCaramelCream(drinkName, size, price);
            else return new NullCoffee();
        }
    }
}
