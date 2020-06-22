using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Services
{
    public interface ICafeShop 
    {
        void InitializeCoffeeSelection(List<Coffee> coffeeLis);
        void LoadOrders();
        Customer CreateNewCustomer(string customerName, List<Order> orderList);
        Coffee FindCoffeeFromShopsSelectionFor(Order order);
        List<Customer> GetCustomerList();
        List<Balance> GetAllUsersBalanceList();
        void UpdateCustomersBalance();
    }

}
