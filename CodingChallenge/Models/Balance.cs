using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models
{
    public class Balance
    {
        decimal orderTotal;
        decimal paymentTotal;
        decimal currentBalance;

        public decimal GetOrderTotal()
        {
            return this.orderTotal;
        }
        public decimal GetPaymentTotal()
        {
            return this.paymentTotal;
        }
        public decimal GetCurrentBalance()
        {
            return this.currentBalance;
        }
        public void UpdateOrderTotal(decimal amount)
        {
            this.orderTotal += amount;
            this.currentBalance += amount;
        }        
        public void UpdatePaymentTotal(decimal amount)
        {
            this.paymentTotal += amount;
            this.currentBalance -= amount;
        }


    }
}
