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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BindingCompleted
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Tuple<string, double>>  values;
     
        public MainPage()
        {
            this.InitializeComponent();
           
        }



        private void nvTopLevelNav_Loaded(object sender, RoutedEventArgs e)
        {

            // Set the initial selecteditem
            foreach (NavigationViewItemBase item in nvTopLevelNav.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Button1")
                {
                    nvTopLevelNav.SelectedItem = item;
                    break;
                }
            }
            contentFrame.Navigate(typeof(HomePage));
        }

        private void nvTopLevelNav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

        }

        private void nvTopLevelNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            String ItemContent = args.InvokedItem.ToString();
            if (ItemContent != null)
            {
                switch (ItemContent)
                {
                    case "Button 1":
                        contentFrame.Navigate(typeof(HomePage));
                        break;

                    case "Button 2":
                        HomePage home = contentFrame.Content as HomePage;
                        if (home != null)
                        {
                            double value = home.slider.Value;                          
                            contentFrame.Navigate(typeof(Page2), value);
                        }
                        else {
                            contentFrame.Navigate(typeof(Page2));
                        }                                         
                        break;

                    case "Button 3":
                        contentFrame.Navigate(typeof(Page3), values);
                        break;
                }
            }

        }

        private void contentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                if (values == null)
                {
                    values = new List<Tuple<string, double>>();

                }
                var waarde = e.Parameter;
                if (waarde.GetType() == typeof(Tuple<string, double>))
                {

                    values.Add(waarde as Tuple<string, double>);
                }

                else if (waarde.GetType() == typeof(List<Tuple<string, double>>))
                {
                    values = waarde as List<Tuple<string, Double>>;
                }
                
            }
        }
    }
}
