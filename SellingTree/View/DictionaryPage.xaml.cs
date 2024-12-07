using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DictionaryPage : Page
    {
        private readonly PlantService _plantService;

        private int pageIn = 1;
        private string _currentSearchTerm = null;

        public DictionaryPage()
        {
            this.InitializeComponent();
            _plantService = new PlantService();
            LoadPlants();
        }

        // Hàm tải danh sách cây từ API
        private async Task LoadPlants()
        {
            try
            {
                LoadingOverlay.Visibility = Visibility.Visible;
                var plants = await _plantService.GetPlantsAsync(pageIn, _currentSearchTerm);
                if (plants != null && plants.Count > 0)
                {
                    PlantList.ItemsSource = plants;
                }
                else
                {
                    PlantInfo.Text = "No plants found.";
                }
            }
            catch (Exception ex)
            {
                PlantInfo.Text = $"Error loading plants: {ex.Message}";
            }
            finally
            {
                LoadingOverlay.Visibility = Visibility.Collapsed;
            }
        }

        // Sự kiện khi người dùng chọn cây từ ListBox
        private async void PlantList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPlant = PlantList.SelectedItem as PlantDictionary;
            if (selectedPlant != null)
            {
                try
                {
                    // Lấy chi tiết về cây đã chọn từ API
                    var plantDetail = await _plantService.GetPlantByIdAsync(selectedPlant.Id);
                    PlantInfo.Text = $"{plantDetail.CommonName}\n{plantDetail.ScientificName}\nFamily: {plantDetail.Family}";
                }
                catch (Exception ex)
                {
                    PlantInfo.Text = $"Error loading plant details: {ex.Message}";
                }
            }
        }

        private async void previous_Click(object sender, RoutedEventArgs e)
        {
            if (pageIn == 1)
            {
                return;
            }
            pageIn--;
            pageNum.Text = pageIn.ToString();
            await LoadPlants();
        }

        private async void next_Click(object sender, RoutedEventArgs e)
        {
            pageIn++;
            pageNum.Text = pageIn.ToString();
            await LoadPlants();
        }

        private void page_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                try
                {
                    int newPage = int.Parse(textBox.Text);
                    if (newPage <= 0)
                    {
                        throw new Exception("Page must be greater than 0");
                    }
                    pageIn = newPage;
                    LoadPlants();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchBox.Text; // Lấy từ khóa tìm kiếm
            pageIn = 1;
            pageNum.Text = pageIn.ToString();
            await LoadPlants();
        }
    }
}
