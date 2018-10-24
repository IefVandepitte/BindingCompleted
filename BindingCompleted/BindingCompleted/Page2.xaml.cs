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
    public sealed partial class Page2 : Page
    {
        private double waarde;

        public Page2()
        {
            this.InitializeComponent();
        }

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                double.TryParse(e.Parameter.ToString(), out waarde);
                page2PositionTextBlock.Text = waarde.ToString();
            }
            
            base.OnNavigatedTo(e);
        }

        private void page2NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            page2NametextBlock.Text = page2NameTextBox.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameter = new Tuple<string, double>(page2NametextBlock.Text, waarde);
           
            Frame.Navigate(typeof(Page3), parameter);
        }
    }
}
