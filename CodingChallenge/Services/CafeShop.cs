using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingChallenge.DataProcessor;
using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;

namespace CodingChallenge.Services
{
    public class CafeShop : ICafeShop
    {
        List<Coffee> coffeeSelection;
        List<Customer> customerList;
        readonly IOrderProcessor orderProcessor;
        readonly IPaymentProcessor paymentProcessor;

        public CafeShop(IOrderProcessor orderProcessor,IPaymentProcessor paymentProcessor)
        {
            coffeeSelection = new List<Coffee>();
            customerList = new List<Customer>();
            this.orderProcessor = orderProcessor;
            this.paymentProcessor = paymentProcessor;
        }

        public void InitializeCoffeeSelection(List<Coffee> coffeeList)
        {
            coffeeSelection = coffeeList;
        }

        public void LoadOrders()
        {
            orderProcessor.LoadOrders();
            foreach (string customerName in orderProcessor.GetAllCustomers())
            {
                if (!String.IsNullOrEmpty(customerName))
                {
                    customerList.Add(CreateNewCustomer(customerName, orderProcessor.GetAllOrdersFrom(customerName)));
                }
            }
        }

        public Customer CreateNewCustomer(string customerName,List<Order> orderList)
        {
            Customer newCustomer = new Customer(customerName);
            if (orderList != null)
            {
                foreach (var order in orderList)
                {
                    var coffee = FindCoffeeFromShopsSelectionFor(order);
                    if (!String.IsNullOrEmpty(coffee.GetName()))
                    {
                        newCustomer.AddNewOrder(coffee);
                        newCustomer.UpdateOrderTotal(coffee.GetPrice());
                    }
                }
            }
            return newCustomer;
        }

        public Coffee FindCoffeeFromShopsSelectionFor(Order order)
        {
            Coffee c;
            if(order!=null && Array.IndexOf(CoffeeType.CoffeeTypesByName(), order.drink) > -1 
                && !String.IsNullOrEmpty(order.size))            
            {
                c = coffeeSelection.FirstOrDefault(d => d.GetSize() == order.size && d.GetName() == order.drink) ?? new NullCoffee();
                return c;
            }           
            return new NullCoffee();
        }
        public List<Customer> GetCustomerList()
        {
            return customerList;
        }

        public List<Balance> GetAllUsersBalanceList()
        {
            List<Balance> balanceListForAllUsers = new List<Balance>();
            foreach (var customer in GetCustomerList())
            {
                balanceListForAllUsers.Add(customer.GetBalance());
            }
            return balanceListForAllUsers;
        }

        public void UpdateCustomersBalance()
        {
            foreach (var payment in paymentProcessor.LoadInputPayment())
            {
                var customer = FindCustomerFrom(payment.user,customerList);
                if (customer != null)
                {
                    customer.UpdateBalance(payment.amount);
                }
            }
        }


        public Customer FindCustomerFrom(string user, List<Customer> customerList)
        {
            return customerList.FirstOrDefault(c => c.GetName() == user);
        }
    }
}
