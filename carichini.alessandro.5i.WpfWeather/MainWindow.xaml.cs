using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace carichini.alessandro._5i.WpfWeather
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async private void Btn_Visualizza_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                btn_Visualizza.Background = Brushes.Red;
                List<Meteo> meteo = new List<Meteo>() { JsonConvert.DeserializeObject<Meteo>(await client.GetStringAsync("https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22")) };
                btn_Visualizza.Background = Brushes.LightBlue;
                lsw_Dati.ItemsSource = meteo;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                btn_Visualizza.Background = Brushes.LightBlue;
            }
        }
    }
}
