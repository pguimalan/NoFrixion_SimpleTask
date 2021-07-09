using Newtonsoft.Json;
using System;
using System.Net;

namespace GetBitCoinPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonStr;

            using (var wc = new WebClient())
            {
                var url = @"https://api.coindesk.com/v1/bpi/currentprice.json";
                jsonStr = wc.DownloadString(url);
            }

            dynamic obj = JsonConvert.DeserializeObject(jsonStr);
            var currentPrice = obj.bpi.EUR.rate.Value;

            Console.WriteLine($"BTC Price EUR {String.Format("{0:n}", currentPrice)}");
        }
    }
}
