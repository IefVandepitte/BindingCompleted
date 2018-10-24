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
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (sliderTextBox != null)
            {
                sliderTextBox.Text = slider.Value.ToString();
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (slider != null)
            {
                 double value;
                 var isparsed =  double.TryParse(sliderTextBox.Text, out value);
                  if (isparsed)
                  {
                      slider.Value = value;
                      slider.InvalidateArrange();
                  }
            }
           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)    
            {

            }
            base.OnNavigatedTo(e);
        }
    }
}
