using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using CodingChallenge.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace CodingChallenge.DataAccess
{
    public class JsonOrderLoader : IOrderLoader
    {
        string path;
        public JsonOrderLoader()
        {
            this.path = ConfigurationManager.AppSettings.Get("OrderJsonPath");
        }

        public JsonOrderLoader(string path)
        {
            this.path = path;
        }
        public List<Order> LoadOrder()
        {
            List<Order> orderList = new List<Order>();
            try
            {
                using (StreamReader r = new StreamReader(@path))
                {
                    string json = r.ReadToEnd();
                    orderList = JsonConvert.DeserializeObject<List<Order>>(json);
                }
            }           
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine("File not found!" + fnf.FileName);
                throw;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error occured during loading order json object:" + ex.Message.ToString());
                throw;
            }

            return orderList;
        }     
    }
}
