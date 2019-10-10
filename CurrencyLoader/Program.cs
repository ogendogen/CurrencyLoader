using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CurrencyLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = ".";
            watcher.Created += File_Created;
            watcher.EnableRaisingEvents = true;
            Console.WriteLine("Listening for .json files started");
            while(true)
            {
                string line = Console.ReadLine();
                if (line == "exit")
                {
                    break;
                }
            }
        }

        private static void File_Created(object sender, FileSystemEventArgs e)
        {
            if (e.Name.EndsWith(".json"))
            {
                try
                {
                    string json = File.ReadAllText(e.Name);
                    //bool isGav = true;
                    //if (json.Contains("APIV4"))
                    //{
                    //    isGav = false;
                    //}

                    //Loader.LoadByHTTP(json, isGav);
                    //Console.WriteLine("HTTP loaded!");

                    Loader.LoadByFTP(json, e.Name);
                    Console.WriteLine($"File {e.Name} loaded by FTP!");
                    File.Delete(e.Name);

                    //Loader.LoadBySQL(json, isGav);
                    //Console.WriteLine("SQL loaded!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error occured! Check log file");
                    File.AppendAllText("errorlog.log", DateTime.Now.ToString() + "|" + ex.Message + "|" + ex.StackTrace);
                }
            }
        }
    }
}
