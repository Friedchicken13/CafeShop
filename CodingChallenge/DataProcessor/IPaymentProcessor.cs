using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.DataProcessor
{
    public interface IPaymentProcessor
    {
        List<Payment> LoadInputPayment();       
    }
}
