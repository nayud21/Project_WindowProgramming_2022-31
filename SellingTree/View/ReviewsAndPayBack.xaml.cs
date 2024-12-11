﻿using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.Model;
using System;
using System.Collections.ObjectModel;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.ComponentModel;
using Windows.Media.Core;
using SellingTree.IDao;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    public class MediaOrImage : INotifyPropertyChanged
    {
        String content { get; set; }
        int isImage { get; set; } = 0;
        int isVideo { get; set; } = 0;
        public MediaOrImage(String source, bool video = false)
        {
            content = source;
            if (video)
                isVideo = 1;
            else isImage = 1;

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ReviewsAndPayBackViewModel
    {

        public FullObservableCollection<MediaOrImage> MediaItems { get; set; } = new FullObservableCollection<MediaOrImage>();
        public ObservableCollection<String> EmojisList { get; set; } = new ObservableCollection<string>
        {"😊", "😄", "😢", "😡", "😂", "❤️", "😍", "😎", "😃", "😇", "😜", "😅", "😆", "😌", "😘", "😗", "😛", "😔", "😖", "😞", "😟", "😤", "😦", "😧", "😨", "😩", "😪", "😫", "😬", "😭", "😮", "😯", "😰", "😱", "😲", "😳", "😴", "😵", "😷", "😸", "😹", "😺", "😻", "😼", "😽", "😾", "😿", "🙁", "🙃", "🙄"

        };

    }
    public sealed partial class ReviewsAndPayBack : Page
    {
        ReviewsAndPayBackViewModel viewModel;
        Product p;
        public ReviewsAndPayBack(Product product, float Average = 0)
           
        {
            this.InitializeComponent();
            p = product;
            ProductName.Text = product.Name;
            Sold.Text = $"{product.Sold}";
            Score.Text = $"{Average}";
            AverageRating.Value = Average;
            ProductImage.Source = new BitmapImage(new Uri(product.ImageSource));
            viewModel = new ReviewsAndPayBackViewModel();
            DataContext = viewModel;
        }

        private void RatingValue_Changed(RatingControl sender, object args)
        {
            String[] rating = { "Tệ", "Hơi tạm", "Ổn", "Tốt", "Tuyệt vời" };
            SolidColorBrush[] foreground = {new SolidColorBrush(Colors.Red), new SolidColorBrush(Colors.Orange),
                new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.Green),
                new SolidColorBrush(Colors.Yellow) };

            ratingControl.Value = Math.Min((int)ratingControl.Value,1);
            Rating.Text = rating[(int)ratingControl.Value - 1];
            Rating.Foreground = foreground[(int)ratingControl.Value - 1];
        }
        public void EmojiButton_Clicked(object sender, RoutedEventArgs e)
        {
            EmojiPopUp.IsOpen = !EmojiPopUp.IsOpen;
        }
        public void Popup_Clicked(object sender, RoutedEventArgs e)
        {
            int t = TextBox.SelectionStart;
            TextBox.Text = TextBox.Text.Insert(t, (sender as Button).Tag as String);
            TextBox.SelectionStart = t + 1;
            EmojiPopUp.IsOpen = false;
        }
        private async void ButtonSend_Clicked(object sender, RoutedEventArgs e)
        {
            
            SendRing.Visibility = Visibility.Visible;
            SendButton.IsEnabled = false;
            PostgreDaoCollection.AddReview(SessionManager.CurrentUser, p, TextBox.Text.ToString(), (int) Math.Min(ratingControl.Value,1));
            SendRing.Visibility = Visibility.Collapsed;


        }

        private async void AddImage_Clicked(object sender, RoutedEventArgs e)
        {
            
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

            var window = MainWindow.Instance;
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            var file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                Image image = new Image { Source = new BitmapImage(new Uri(file.Path)), Width = 120, Height = 120, Margin = new Thickness(5) };
                viewModel.MediaItems.Add(new MediaOrImage(file.Path));
                ImageContainer.Children.Add(image);
            }
            else
            {
                EmojiPopUp.IsOpen = true;
            }

        }

        private async void AddVideo_Clicked(object sender, RoutedEventArgs e)
        {
            var openPicker = new FileOpenPicker(); 
            var window = MainWindow.Instance; 
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window); 
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd); 
            openPicker.ViewMode = PickerViewMode.Thumbnail; 
            openPicker.SuggestedStartLocation = PickerLocationId.VideosLibrary; 
            openPicker.FileTypeFilter.Add(".mp4"); 
            openPicker.FileTypeFilter.Add(".mkv"); 
            openPicker.FileTypeFilter.Add(".wmv"); 
            var file = await openPicker.PickSingleFileAsync(); 
            if (file != null) 
            { 
                MediaPlayerElement mediaPlayer = new MediaPlayerElement 
                { Source = MediaSource.CreateFromUri(new Uri(file.Path)), Width = 120, Height = 120, 
                    AutoPlay = true, Margin = new Thickness(5) };
                ImageContainer.Children.Add(mediaPlayer); 
            }
        }

        private void LoseFocus(UIElement sender, LosingFocusEventArgs args)
        {
            EmojiPopUp.IsOpen = false;
        }
    }
}
