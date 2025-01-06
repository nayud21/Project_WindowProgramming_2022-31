using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.IDao;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using static SellingTree.IDao.PostgreDaoCollection;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPageAdmin : Page
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public AccountPageAdmin()
        {
            this.InitializeComponent();
            if (SessionManager.IsLoggedIn())
            {
                usernameTextBlock.Text = SessionManager.CurrentUser.Name;
                avatarImage.Source = new BitmapImage(new Uri(SessionManager.CurrentUser.ImageLocation));
                LoadOrders();
                LoadProducts();
            }
        }

        private const int PageSize = 6;
        private int currentOrderPage = 1;
        private int currentProductPage = 1;

        private void LoadOrders()
        {
            IDaoOrder daoOrder = new PostgreDaoOrder();
            var orders = daoOrder.GetOrders()
                                 .Skip((currentOrderPage - 1) * PageSize)
                                 .Take(PageSize)
                                 .ToList();
            ordersListView.ItemsSource = orders;
        }

        private void LoadProducts()
        {
            var products = PostgreDaoCollection.GetAllProduct()
                                               .Skip((currentProductPage - 1) * PageSize)
                                               .Take(PageSize)
                                               .ToList();
            productsListView.ItemsSource = products;
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Logout the user
            SessionManager.Logout();

            // Navigate back to LoginPage
            this.Frame.Navigate(typeof(LoginPage));
        }

        private async void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            await addProductDialog.ShowAsync();
        }

        private async void EditProductButton_Click(object sender,RoutedEventArgs e)
        {
            // Set the text boxes with the selected product's details
            var product = (Product)((Button)sender).DataContext;
            editProductDialog.Tag = product;    
            editProductNameTextBox.Text = product.Name;
            editProductDescriptionTextBox.Text = product.Description;
            editProductPriceTextBox.Text = product.Price.ToString();
            editProductStoreTextBox.Text = product.Stored.ToString();
            await editProductDialog.ShowAsync();
        }

        private async void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Store the product to be deleted
            var product = (Product)((Button)sender).DataContext;
            deleteProductDialog.Tag = product;
            await deleteProductDialog.ShowAsync();
        }

        private void AddProductDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Add product logic
            //get id for new product
            int id = Products.Count + 1;

            var newProduct = new Product
            {
                PID = id,
                Name = addProductNameTextBox.Text,
                Price = int.Parse(addProductPriceTextBox.Text),
                Stored = int.Parse(addProductStoreTextBox.Text),
                Description = addProductDescriptionTextBox.Text,
                ImageSource = addProductImageTextBox.Text,
                Sold = 0
            };
            // Add newProduct to the product list
            Products.Add(newProduct);
            // Add newProduct to the database
            IDaoProduct daoProduct = new PostgreDaoProduct();
            daoProduct.InsertProduct(newProduct);


        }

        private void EditProductDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Edit product logic
            var product = (Product)editProductDialog.Tag;
            //Product product = (Product)(Product)editProductDialog.Tag;
            product.Name = editProductNameTextBox.Text;
            product.Description = editProductDescriptionTextBox.Text;
            product.Price = int.Parse(editProductPriceTextBox.Text);
            product.Stored = int.Parse(editProductStoreTextBox.Text);

            // Update product in the product list
            IDaoProduct daoProduct = new PostgreDaoProduct();
            
            daoProduct.UpdateProduct(product);

        }

        private void DeleteProductDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Delete product logic
            var product = (Product)deleteProductDialog.Tag;
            // Remove product from the product list
            Products.Remove(product);
            // Remove product from the database
            IDaoProduct daoProduct = new PostgreDaoProduct();
            daoProduct.DeleteProduct(product);
        }

        private async void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Viết cho tôi cái hàm này để chọn file ảnh từ máy tính
            // Create a FileOpenPicker
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            // Show the FileOpenPicker
            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.m_window);
            InitializeWithWindow.Initialize(openPicker, hwnd);

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                //// Set the image source to the selected image
                //var bitmapImage = new BitmapImage();
                //bitmapImage.UriSource = new Uri(file.Path);
                //// hiển thị link ảnh đã chọn lên textbox
                //addProductImageTextBox.Text = file.Path;
                //tôi muốn khi chọn file, nó sẽ upload file lên supabase và trả về link ảnh
                // hãy giúp tôi thực hiện điều đó
                // Upload file to Supabase storage
                var supabase = new Supabase.Client("https://thfctareaaikcsvjyrzn.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRoZmN0YXJlYWFpa2Nzdmp5cnpuIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTczMjE1MDAzNiwiZXhwIjoyMDQ3NzI2MDM2fQ.z2cvnUcgX_5aOtDQ-E1Jj7UOqvywRenIsE6DPmhLO0U");
                await supabase.InitializeAsync();

                var storage = supabase.Storage;
                var bucket = storage.From("assets/Untitled folder");

                using (var stream = await file.OpenStreamForReadAsync())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        var fileBytes = memoryStream.ToArray();
                        var response = await bucket.Upload(fileBytes, file.Name);
                        if (!string.IsNullOrEmpty(response))
                        {
                            // Get the public URL of the uploaded file
                            var publicUrl = bucket.GetPublicUrl(file.Name);
                            addProductImageTextBox.Text = publicUrl;
                        }
                        else
                        {
                            // Handle upload error
                            // You can show a message to the user or log the error
                        }
                    }
                }

            }
        }
        private void PreviousOrderPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentOrderPage > 1)
            {
                currentOrderPage--;
                LoadOrders();
                UpdateOrderPageText();
            }
        }

        private void NextOrderPage_Click(object sender, RoutedEventArgs e)
        {
            currentOrderPage++;
            LoadOrders();
            UpdateOrderPageText();
        }

        private void PreviousProductPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentProductPage > 1)
            {
                currentProductPage--;
                LoadProducts();
                UpdateProductPageText();
            }
        }

        private void NextProductPage_Click(object sender, RoutedEventArgs e)
        {
            currentProductPage++;
            LoadProducts();
            UpdateProductPageText();
        }

        private void UpdateOrderPageText()
        {
            orderPageTextBlock.Text = $"Page {currentOrderPage}";
        }

        private void UpdateProductPageText()
        {
            productPageTextBlock.Text = $"Page {currentProductPage}";
        }
    }
}
