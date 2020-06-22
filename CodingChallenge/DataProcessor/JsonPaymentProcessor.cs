using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingChallenge.DataAccess;
using CodingChallenge.Models;

namespace CodingChallenge.DataProcessor
{
    public class JsonPaymentProcessor : IPaymentProcessor
    {
        IPaymentLoader paymentLoader;

        public JsonPaymentProcessor(IPaymentLoader paymentLoader)
        {
            this.paymentLoader = paymentLoader;
        }

        public List<Payment>  LoadInputPayment()
        {
            return paymentLoader.LoadPayment();
        }

      
    }
}
