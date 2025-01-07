using Microsoft.UI;
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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Windows.Gaming.Input.ForceFeedback;
using System.Threading.Tasks;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    public class MediaOrImage : INotifyPropertyChanged
    {
        public String content { get; set; }
        public int isImage { get; set; } = 0;
        public int isVideo { get; set; } = 0;
        public MediaOrImage(String source, bool video = false)
        {
            content = source;
            if (video)
                isVideo = 1;
            else isImage = 1;

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ReviewsAndPayBackViewModel:INotifyPropertyChanged
    {
        public ReviewsAndPayBackViewModel()
        {
            Task();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void Task()
        { // Load the file from the app's assets folder
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/emojis.txt"));

            // Read all lines from the file asynchronously
            var lines = await Windows.Storage.FileIO.ReadLinesAsync(file);

            // Populate the ObservableCollection with the lines from the file
            EmojisList = new ObservableCollection<string>(lines);
        }
        public List<MediaOrImage> MediaItems { get; set; } = new List<MediaOrImage>();
        public ObservableCollection<String> EmojisList { get; set; }    

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

            ratingControl.Value = Math.Max((int)ratingControl.Value, 1);
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
            int Mode = 0;
            if (Toggle1.IsOn) Mode += 4;
            if (Toggle2.IsOn) Mode += 2;
            if (Toggle3.IsOn) Mode += 1;
            await PostgreDaoCollection.AddReview(SessionManager.CurrentUser, p, TextBox.Text.ToString(), viewModel.MediaItems, (int)Math.Min(ratingControl.Value, 1), Mode);
            foreach (var item in viewModel.MediaItems)
                if (item.isVideo == 1)
                {
                    IDao.SupabaseStorageService.getInstance().UploadVideoAsync(item.content, "Reviews");

                }
                else
                {
                    SupabaseStorageService.getInstance().UploadImageAsync(item.content, "Reviews");
                }
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
                var bitmapImage = new BitmapImage(new Uri(file.Path));

                var image = new Image
                {
                    Source = bitmapImage,
                    Width = 120,
                    Height = 120,
                    Margin = new Thickness(5)
                };

                var deleteButton = new Button
                {
                    Content = "x",
                    Width = 20,
                    Height = 20,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Background = new SolidColorBrush(Colors.Red),
                    Foreground = new SolidColorBrush(Colors.White)
                };
                var imageStackPanel = new StackPanel
                {
                    Width = 120,
                    Height = 120,
                    Margin = new Thickness(5),
                    Children = { image, deleteButton }
                };

                deleteButton.Click += (s, args) =>
                {
                    ImageContainer.Children.Remove(imageStackPanel);
                    viewModel.MediaItems.Remove(viewModel.MediaItems.FirstOrDefault(m => m.content == file.Path));
                };


                viewModel.MediaItems.Add(new MediaOrImage(file.Path));
                ImageContainer.Children.Add(imageStackPanel);
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
                {
                    Source = MediaSource.CreateFromUri(new Uri(file.Path)),
                    Width = 120,
                    Height = 120,
                    AutoPlay = true,
                    Margin = new Thickness(5)
                };
                ImageContainer.Children.Add(mediaPlayer);
            }
        }

        private void LoseFocus(UIElement sender, LosingFocusEventArgs args)
            {
                EmojiPopUp.IsOpen = false;
            }
        }
    }
