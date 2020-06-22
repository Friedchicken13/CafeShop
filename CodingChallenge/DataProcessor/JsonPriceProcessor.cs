using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CodingChallenge.DataAccess;
using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using CodingChallenge.Services;
using Newtonsoft.Json;

namespace CodingChallenge.DataProcessor
{
    public class JsonPriceProcessor : IPriceProcessor
    {
        List<Price> priceList;
        IBeverageFactory beverageFactory;
        IPriceLoader priceLoader;

        public JsonPriceProcessor(IBeverageFactory beverageFactory,IPriceLoader priceLoader)
        {
            priceList = new List<Price>();
            this.beverageFactory = beverageFactory;
            this.priceLoader = priceLoader;
        }
       
        public List<Coffee> ProcessInputPrice()
        {
            return beverageFactory.CreateCoffees(priceLoader.LoadPrice());
        }


    }
}
