using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.DataAccess
{
    public interface IPaymentLoader
    {
        List<Payment> LoadPayment();
    }
}
