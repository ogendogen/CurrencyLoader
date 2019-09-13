using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using FluentFTP;

namespace CurrencyLoader
{
    public static class Loader
    {
        public static void LoadByHTTP(string json)
        {
            WebClient client = new WebClient();
            string downloaded = client.DownloadString("http://localhost/cloud.php?currency=" + json);
        }

        public static void LoadByFTP(string json, string fileName)
        {
            FtpClient client = new FtpClient("127.0.0.1", 21, "root", "root");
            client.Connect();
            client.RetryAttempts = 3;
            client.UploadFile(fileName, "/test/" + fileName);
            client.Disconnect();
        }

        public static bool LoadBySQL(string json)
        {
            Database db = Database.GetInstance("127.0.0.1", "root", "", "currencies");
            QueryManager manager = new QueryManager(db);
            var jsonObject = Deserializer.DeserializeFinalOutput(json);

            int retID = manager.InsertToGAV(jsonObject.Currency, jsonObject.Date, jsonObject.TargetCurrencies.CAD, jsonObject.TargetCurrencies.HKD, jsonObject.TargetCurrencies.ISK,
                jsonObject.TargetCurrencies.PHP, jsonObject.TargetCurrencies.DKK, jsonObject.TargetCurrencies.HUF, jsonObject.TargetCurrencies.CZK, jsonObject.TargetCurrencies.GBP,
                jsonObject.TargetCurrencies.RON, jsonObject.TargetCurrencies.SEK, jsonObject.TargetCurrencies.INR, jsonObject.TargetCurrencies.BRL, jsonObject.TargetCurrencies.RUB,
                jsonObject.TargetCurrencies.HRK, jsonObject.TargetCurrencies.JPY, jsonObject.TargetCurrencies.THB, jsonObject.TargetCurrencies.CHF, jsonObject.TargetCurrencies.EUR,
                jsonObject.TargetCurrencies.MYR, jsonObject.TargetCurrencies.BGN, jsonObject.TargetCurrencies.TRY, jsonObject.TargetCurrencies.CNY, jsonObject.TargetCurrencies.NOK,
                jsonObject.TargetCurrencies.NZD, jsonObject.TargetCurrencies.ZAR, jsonObject.TargetCurrencies.USD, jsonObject.TargetCurrencies.MXN, jsonObject.TargetCurrencies.SGD,
                jsonObject.TargetCurrencies.AUD, jsonObject.TargetCurrencies.ILS, jsonObject.TargetCurrencies.KRW, jsonObject.TargetCurrencies.PLN);

            return retID > -1;
        }
    }
}
