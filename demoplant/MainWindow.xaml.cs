using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demoplant
{
    public sealed partial class MainWindow : Window
    {
        private readonly PlantService _plantService;

        private int pageIn = 1;
        private string _currentSearchTerm = null;

        public MainWindow()
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
            var selectedPlant = PlantList.SelectedItem as Plant;
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
            if(pageIn == 1)
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
                    if(newPage <= 0)
                    {
                        throw new Exception("Page must be greater than 0");
                    }
                    pageIn = newPage;
                    LoadPlants();
                }
                catch(Exception ex)
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
