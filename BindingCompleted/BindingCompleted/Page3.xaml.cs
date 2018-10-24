using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BindingCompleted
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page3 : Page
    {
        private const string valueContainer = "valueContainter";
        private const string values = "values";
        private Tuple<string, double> payload ;
        private Windows.Storage.ApplicationDataContainer localSettings;
        public List<Tuple<String, double>> waardes = new List<Tuple<String, double>>();

        public Page3()
        {
             localSettings =  Windows.Storage.ApplicationData.Current.LocalSettings;
            this.payload = new Tuple<string, double>("", 0);
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            bool hasContainer = localSettings.Containers.ContainsKey(valueContainer);
            bool hasSetting = false;
            if (hasContainer)
            {
                hasSetting = localSettings.Containers[valueContainer].Values.ContainsKey(values);
            }
            if (hasSetting)
            {
                var values = e.Parameter;
                if (values != null && values.GetType() == typeof(List<Tuple<string, double>>))
                {
                    List<Person> people = new List<Person>();
                    foreach (var value in (List<Tuple<string, double>>)values) {
                        Person person = new Person( value.Item1, value.Item2);
                        people.Add(person);

                    }
                    StatsGridView.ItemsSource = people;
                }
                

            }

            var input = e.Parameter;
            if (input != null && input.GetType() == typeof(Tuple<String, double>))
            {
                payload = input as Tuple<String, double>;
                var text = "Ontvangen \nnaam: " + payload.Item1.ToString() + "\npositie: " + payload.Item2.ToString();


                var tuple = new Tuple<String, double>(payload.Item2.ToString(), payload.Item2);
                waardes.Add(tuple);
                toegevoegdTextBLock.Text = text;
                //complexe data kan niet
                //persisteerWaarde(waardes);

            }
            else if (input != null && input.GetType() == typeof(List<Tuple<string,double>>))
            {
                waardes = input as List<Tuple<string, double>>;
                var index = waardes.Count() - 1;
                var text = "Ontvangen \nnaam: " + waardes[index].Item1.ToString() + "\npositie: " + waardes[index].Item2.ToString();
                toegevoegdTextBLock.Text = text;
            }      
            base.OnNavigatedTo(e);
        }

        private void persisteerWaarde(List<Tuple<String, String>> input)
        {
           

            Windows.Storage.ApplicationDataContainer container =
                localSettings.CreateContainer(valueContainer,
                Windows.Storage.ApplicationDataCreateDisposition.Always);

            if (localSettings.Containers.ContainsKey(valueContainer))
            {
                localSettings.Containers[valueContainer].Values[values] = input;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }
    }
}
