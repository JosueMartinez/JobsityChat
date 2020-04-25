using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace StockBot
{
    public class BotTasks
    {
        private static string GetCSV(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }

        private static List<string> GetQuoteValues(string stockCode)
        {
            string url = $"https://stooq.com/q/l/?s={stockCode}&f=sd2t2ohlcv&h&e=csv";

            string fileList = GetCSV(url);
            string[] tempStr;

            fileList = fileList.Replace('\r', '|').Replace("\n", string.Empty);

            tempStr = fileList.Split('|');

            List<string> values = tempStr[1].Split(',').ToList();

            return values;
        }

        public static string GetStockMessage(string stockCode)
        {
            var values = GetQuoteValues(stockCode);
            return string.Format($"{values[0]} quote is ${values[6]} per share");
        }
    }
}
