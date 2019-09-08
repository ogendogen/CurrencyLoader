using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace CurrencyLoader
{
    public static class Loader
    {
        public static void LoadByHTTP(string json)
        {
            WebClient client = new WebClient();
            string downloaded = client.DownloadString("http://localhost/cloud.php?currency=" + json);
            Console.WriteLine(downloaded);
        }

        public static void LoadByFTP(string json)
        {
            throw new NotImplementedException();
        }

        public static void LoadBySQL(string json)
        {
            throw new NotImplementedException();
        }
    }
}
