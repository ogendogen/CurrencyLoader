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
        public static void LoadByHTTP(string json, bool isGav)
        {
            WebClient client = new WebClient();
            if (isGav)
            {
                client.DownloadString("http://localhost/cloud.php?gav=" + json);
            }
            else
            {
                client.DownloadString("http://localhost/cloud.php?lav=" + json);
            }
        }

        public static void LoadByFTP(string json, string fileName)
        {
            FtpClient client = new FtpClient("127.0.0.1", 21, "root", "root");
            client.Connect();
            client.RetryAttempts = 3;
            bool ret = client.UploadFile(fileName, "/test/" + fileName);
            client.Disconnect();
        }

        public static bool LoadBySQL(string json, bool isGav)
        {
            Database db = Database.GetInstance("127.0.0.1", "root", "", "currencies");
            QueryManager manager = new QueryManager(db);

            int retID = -1;
            if (isGav)
            {
                var gavObject = Deserializer.DeserializeFinalOutput(json);
                retID = manager.InsertToGAV(gavObject.Currency, gavObject.Date, gavObject.TargetCurrencies.CAD, gavObject.TargetCurrencies.HKD, gavObject.TargetCurrencies.ISK,
    gavObject.TargetCurrencies.PHP, gavObject.TargetCurrencies.DKK, gavObject.TargetCurrencies.HUF, gavObject.TargetCurrencies.CZK, gavObject.TargetCurrencies.GBP,
    gavObject.TargetCurrencies.RON, gavObject.TargetCurrencies.SEK, gavObject.TargetCurrencies.INR, gavObject.TargetCurrencies.BRL, gavObject.TargetCurrencies.RUB,
    gavObject.TargetCurrencies.HRK, gavObject.TargetCurrencies.JPY, gavObject.TargetCurrencies.THB, gavObject.TargetCurrencies.CHF, gavObject.TargetCurrencies.EUR,
    gavObject.TargetCurrencies.MYR, gavObject.TargetCurrencies.BGN, gavObject.TargetCurrencies.TRY, gavObject.TargetCurrencies.CNY, gavObject.TargetCurrencies.NOK,
    gavObject.TargetCurrencies.NZD, gavObject.TargetCurrencies.ZAR, gavObject.TargetCurrencies.USD, gavObject.TargetCurrencies.MXN, gavObject.TargetCurrencies.SGD,
    gavObject.TargetCurrencies.AUD, gavObject.TargetCurrencies.ILS, gavObject.TargetCurrencies.KRW, gavObject.TargetCurrencies.PLN);
            }
            else
            {
                var lavObject = Deserializer.DeserializeMediatedSchema(json);
                retID = manager.InsertToLAV(lavObject.API, lavObject.APIV4); 
            }

            return retID > -1;
        }
    }
}
