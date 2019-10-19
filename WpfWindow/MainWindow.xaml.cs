using CurrencyLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsListening { get; set; } = false;
        public FileSystemWatcher Watcher { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Watcher = new FileSystemWatcher();
            Watcher.Path = ".";
            Watcher.Created += File_Created;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!radioButtonHTTP.IsChecked.Value && !radioButtonFTP.IsChecked.Value && !radioButtonSQL.IsChecked.Value)
            {
                MessageBox.Show("Choose method first!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (IsListening)
            {
                Watcher.EnableRaisingEvents = false;
                IsListening = false;
                AppendLog("Listening for .json files stopped");
                button.Content = "Start";
            }
            else
            {
                Watcher.EnableRaisingEvents = true;
                IsListening = true;
                AppendLog("Listening for .json files started");
                button.Content = "Stop";
            }
        }

        private void File_Created(object sender, FileSystemEventArgs e)
        {
            if (e.Name.EndsWith(".json"))
            {
                try
                {
                    string json = File.ReadAllText(e.Name);
                    bool isGav = true;
                    if (json.Contains("APIV4"))
                    {
                        isGav = false;
                    }

                    if (radioButtonHTTP.IsChecked.Value)
                    {
                        Loader.LoadByHTTP(json, isGav);
                        AppendLog("HTTP loaded!");
                    }
                    else if (radioButtonFTP.IsChecked.Value)
                    {
                        Loader.LoadByFTP(json, e.Name);
                        AppendLog($"File {e.Name} loaded by FTP!");
                        File.Delete(e.Name);
                    }
                    else if (radioButtonSQL.IsChecked.Value)
                    {
                        Loader.LoadBySQL(json, isGav);
                        AppendLog("SQL loaded!");
                    }
                }
                catch(Exception ex)
                {
                    AppendLog("Error occured! Check log file");
                    File.AppendAllText("errorlog.log", DateTime.Now.ToString() + "|" + ex.Message + "|" + ex.StackTrace);
                }
            }
        }

        private void AppendLog(string log)
        {
            textBox.Dispatcher.Invoke(() => 
            {
                textBox.AppendText(log + "\r\n");
                textBox.ScrollToEnd();
            });
        }
    }
}
