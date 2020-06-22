using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using CodingChallenge.Models;
using Newtonsoft.Json;

namespace CodingChallenge.DataAccess
{
    public class JsonPriceLoader : IPriceLoader
    {
        string path;

        public JsonPriceLoader()
        {
            path = ConfigurationManager.AppSettings.Get("PriceJsonPath");
        }

        public JsonPriceLoader(string path)
        {
            this.path = path;
        }

        public List<Price> LoadPrice()
        {
            List<Price> priceList= new List<Price>();
            try
            {
                using (StreamReader r = new StreamReader(@path))
                {
                    string json = r.ReadToEnd();
                    priceList = JsonConvert.DeserializeObject<List<Price>>(json);
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
            return priceList;
        }        
    }
}
