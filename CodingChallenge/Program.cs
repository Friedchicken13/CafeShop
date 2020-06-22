using CodingChallenge.DataProcessor;
using CodingChallenge.DataAccess;
using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using CodingChallenge.Services;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace CodingChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IPriceProcessor myJsonPriceProcessor = new JsonPriceProcessor(new BeverageFactory(), new JsonPriceLoader());
            IOrderProcessor myJsonOrderProcessor = new JsonOrderProcessor(new JsonOrderLoader());
            IPaymentProcessor myJsonPaymentProcessor = new JsonPaymentProcessor(new JsonPaymentLoader());
            IResultProvider myJsonSerializer = new ResultProvider();

            ICafeShop myCafeShop = new CafeShop(myJsonOrderProcessor, myJsonPaymentProcessor);

            List<Coffee> coffeeList = myJsonPriceProcessor.ProcessInputPrice();

            myCafeShop.InitializeCoffeeSelection(coffeeList);
            myCafeShop.LoadOrders();            
            myCafeShop.UpdateCustomersBalance();

            myJsonSerializer.Create(myCafeShop.GetCustomerList());
        }


        
    }
}
