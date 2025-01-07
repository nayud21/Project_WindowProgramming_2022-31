using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GuideCategory : Page
    {
        public GuideCategory()
        {
            this.InitializeComponent();
            InitialGuideCategory();
        }

        private async void InitialGuideCategory()
        {

            try
            {
                await webView.EnsureCoreWebView2Async(null);
                webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                //webView.CoreWebView2.NavigationFailed += CoreWebView2_NavigationFailed;
                webView.CoreWebView2.Navigate("https://www.gardenia.net/guides");

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;  // Rethrow exception if you want it to propagate
            }

        }

        private void CoreWebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                string toastXmlString = @"
                <toast>
                    <visual>
                        <binding template='ToastGeneric'>
                            <text> 🍃 Guide Category Connect successful </text>
                            <image placement=""appLogoOverride"" src='ms-appx:///Assets/toast_guide_category.png'/>
                            <text placement=""attribution"" > DAD</text>
                        </binding>
                    </visual>
                </toast>";

                XmlDocument toastXml = new XmlDocument();
                toastXml.LoadXml(toastXmlString);

                ToastNotification toast = new ToastNotification(toastXml);

                ToastNotificationManager.CreateToastNotifier().Show(toast);
            }
            else
            {

                System.Diagnostics.Debug.WriteLine("Navigation failed: " + e.WebErrorStatus);
            }
        }

        //private void CoreWebView2_NavigationFailed(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationFailedEventArgs e)
        //{
        //    System.Diagnostics.Debug.WriteLine("Failed to load page: " + e.WebErrorStatus);
        //}

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CoreWebView2.CanGoBack)
            {
                webView.CoreWebView2.GoBack();
            }
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.Reload();
        }



    }
}
