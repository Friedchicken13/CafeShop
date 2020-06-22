using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CodingChallenge.Models;
using Newtonsoft.Json;

namespace CodingChallenge.DataAccess
{
    public class ResultProvider : IResultProvider
    {

        public void Create(List<Customer> customer)
        {
            File.WriteAllText(@"..\..\..\Data\result.json", ComposeResult(customer));
        }

        public string ComposeResult(List<Customer> customerList)
        {
            List<ResultObject> resultList = new List<ResultObject>();
            foreach (var customer in customerList)
            {
                resultList.Add(new ResultObject()
                {
                    user = customer.GetName(),
                    order_total = customer.GetBalanceOrderTotal(),
                    payment_total = customer.GetPaymentTotal(),
                    balance = Math.Round(customer.GetCurrentBalance(), 2)

                });
            }
            return JsonConvert.SerializeObject(resultList, Formatting.Indented, new DecimalJsonConverter());
        }  
    }



   
}
