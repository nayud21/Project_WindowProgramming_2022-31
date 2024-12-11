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
using static SellingTree.IDao.PostgreDaoCollection;

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

        private void LoadOrders()
        {
            IDaoOrder daoOrder = new PostgreDaoOrder();
            var orders = daoOrder.GetOrders();
            ordersListView.ItemsSource = orders;
        }
        private void LoadProducts()
        {
            Products = PostgreDaoCollection.GetAllProduct();
            productsListView.ItemsSource = Products;
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
                ImageSource = "https://thfctareaaikcsvjyrzn.supabase.co/storage/v1/object/public/assets/FengShuiCollection/xuongrong.jpg",
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
    }
}
