using CodingChallenge.Models.CoffeeSelection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models
{
    public class Customer 
    {
        readonly string name;
        List<Coffee> orders;
        Balance balance;

        public Customer(string name)
        {
            this.name = name;
            this.orders = new List<Coffee>();
            this.balance = new Balance();
        }

        public void AddNewOrder(Coffee coffee)
        {
            orders.Add(coffee);
        }       

        public List<Coffee> GetAllOrders()
        {
            return this.orders;
        }

        public decimal GetBalanceOrderTotal()
        {
            return this.balance.GetOrderTotal();
        }

        public string GetName()
        {
            return this.name;
        }

        public Balance GetBalance()
        {
            return this.balance;
        }       

        public decimal GetCurrentBalance()
        {
            return this.balance.GetCurrentBalance();
        }

        public decimal GetPaymentTotal()
        {
            return this.balance.GetPaymentTotal();
        }
        public void UpdateOrderTotal(decimal amount)
        {
            this.balance.UpdateOrderTotal(amount);
        }
        public void UpdateBalance(decimal amount)
        {
            this.balance.UpdatePaymentTotal(amount);
        }
    }
}
