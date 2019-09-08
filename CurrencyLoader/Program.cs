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
            Console.ReadLine();
        }

        private static void File_Created(object sender, FileSystemEventArgs e)
        {
            if (e.Name.EndsWith(".json"))
            {
                string json = File.ReadAllText(e.Name);

                Loader.LoadByHTTP(json);
                Console.WriteLine("HTTP loaded!");

                Loader.LoadByFTP(json, e.Name);
                Console.WriteLine("FTP loaded!");
                File.Delete(e.Name);

                //Loader.LoadBySQL(json);
                //Console.WriteLine("SQL loaded!");
            }
        }
    }
}
