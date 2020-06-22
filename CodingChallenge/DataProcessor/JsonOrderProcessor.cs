using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodingChallenge.DataAccess;
using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using Newtonsoft.Json;

namespace CodingChallenge.DataProcessor
{
    public class JsonOrderProcessor : IOrderProcessor
    {
        List<Order> orderList;
        IOrderLoader orderLoader;

        public JsonOrderProcessor(IOrderLoader orderLoader)
        {
            this.orderLoader = orderLoader;
        }

        public void LoadOrders()
        {
            orderList = orderLoader.LoadOrder();
        }

        public string[] GetAllCustomers()
        {
            return orderList.Select(t => t.user).Distinct().ToArray();
        }

        public List<Order> GetAllOrdersFrom(string user)
        {
            return orderList.Where(t => t.user == user).ToList();
        }

        public List<Order> GetAllOrders()
        {
            return orderList;
        }
    }
}
