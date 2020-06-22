using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.DataAccess
{
    public interface IResultProvider
    {
        void Create(List<Customer> customer);
        string ComposeResult(List<Customer> customerList);
    }
}
