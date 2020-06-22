using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using CodingChallenge.Models;
using Newtonsoft.Json;

namespace CodingChallenge.DataAccess
{
    public class JsonPaymentLoader : IPaymentLoader
    {

        string path;

        public JsonPaymentLoader()
        {
            path = ConfigurationManager.AppSettings.Get("PaymentJsonPath");
        }

        public JsonPaymentLoader(string path)
        {
            this.path = path;
        }

        public List<Payment> LoadPayment()
        {
            List<Payment> paymentList = new List<Payment>();
            try
            {
                using (StreamReader r = new StreamReader(@path))
                {
                    string json = r.ReadToEnd();
                    paymentList = JsonConvert.DeserializeObject<List<Payment>>(json);
                }
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine("File not found!" + fnf.FileName);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured during loading prices json object:" + ex.Message.ToString());
                throw;
            }
            return paymentList;
        }
    }
}
