using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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
using MyLogin.UserControls;

namespace MyLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string URL = @"https://www.filipekberg.se/rss/";

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BusyIndicator.Visibility = Visibility.Visible;

                var rssUpdate = await GetRssAsync(URL);

                var loginUpdate = Task.Run(() =>
                {
                    Thread.Sleep(3000);

                    btnLogin.Content = "Cheers";
                });

                var someTask = Task.Delay(2500);

                await Task.WhenAll(loginUpdate, someTask);

                BusyIndicator.Visibility = Visibility.Hidden;
            }
            catch (Exception exception)
            {
                tbText.Text = "Failed.";
                BusyIndicator.Visibility = Visibility.Hidden;
            }
            
        }

        private async Task<string> GetRssAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = await client.GetAsync(url);

                var result = await request.Content.ReadAsStringAsync();

                return result;
            }
        }

        private void LoginAsyngTplWay()
        {
            Task sleeper = Task.Run(() =>
            {
                Thread.Sleep(3000);
            });

            sleeper.ContinueWith((s) => {
                if (sleeper.IsCompleted)
                {
                    Dispatcher.Invoke(() =>
                    {
                        btnLogin.Content = "Finished!";
                    });
                }
            });
        }
    }
}
