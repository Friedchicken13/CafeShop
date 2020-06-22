using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.DataProcessor
{
    public interface IOrderProcessor
    {
        void LoadOrders();
        string[] GetAllCustomers();
        List<Order> GetAllOrdersFrom(string user);
        List<Order> GetAllOrders();
    }
}
