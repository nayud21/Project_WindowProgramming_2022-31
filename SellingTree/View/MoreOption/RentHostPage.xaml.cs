using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree.View.MoreOption
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RentHostPage : Page
    {
        public RentHostPage()
        {
            this.InitializeComponent();
        }

        private bool IsAnyRadioButtonChecked()
        {
            return host_1.IsChecked == true || host_2.IsChecked == true || host_3.IsChecked == true;
        }

        private void ConfirmHosting_Click(object sender, RoutedEventArgs e)
        {

            bool isAnyRadioButtonChecked = IsAnyRadioButtonChecked();

            if (Agreement.IsChecked == false)
            {
                AgreementConfirm.IsOpen = true;
            }
            if (!isAnyRadioButtonChecked)
            {
                HostSelected.IsOpen = true;
            }
            if(Agreement.IsChecked == true)
            {
                // thanh toan
            }
        }

        private void Agreement_Checked(object sender, RoutedEventArgs e)
        {
            AgreementConfirm.IsOpen = false;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            HostSelected.IsOpen = false;
        }
    }
}
