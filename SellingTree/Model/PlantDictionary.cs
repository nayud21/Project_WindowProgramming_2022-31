using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Net.Http;

namespace SellingTree.Model
{
    public class PlantDictionary
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("common_name")]
        public string CommonName { get; set; }

        [JsonProperty("scientific_name")]
        public string ScientificName { get; set; }

        [JsonProperty("family")]
        public string Family { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }

    public class ApiResponse
    {
        public List<PlantDictionary> Data { get; set; }
    }

    public class PlantService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "8IDTictNEN47qWYztN7j_ggesghd-WmkWnY3ocDOMis";
        //private const string ApiUrl = "https://trefle.io/api/v1/plants?token=8IDTictNEN47qWYztN7j_ggesghd-WmkWnY3ocDOMis";
        private const string ApiUrl = "https://trefle.io/api/v1/plants";

        public PlantService()
        {
            _httpClient = new HttpClient();
            //_httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        }

        // Lấy danh sách các cây từ API
        public async Task<List<PlantDictionary>> GetPlantsAsync(int page = 1, string search = null)
        {
            //var response = await _httpClient.GetStringAsync($"{ApiUrl}&page={page}");
            string searchQuery = string.IsNullOrEmpty(search) ? "" : $"&q={search}";
            var response = await _httpClient.GetStringAsync($"{ApiUrl}?token={ApiKey}&page={page}{searchQuery}");
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response); // Deserialize thành ApiResponse

            Console.WriteLine(response); // Kiểm tra JSON trả về

            return apiResponse?.Data ?? new List<PlantDictionary>(); // Trả về danh sách Plant từ Data
        }

        // Lấy chi tiết một cây theo ID
        public async Task<PlantDictionary> GetPlantByIdAsync(int plantId)
        {
            var response = await _httpClient.GetStringAsync($"{ApiUrl}/{plantId}");
            var plantData = JsonConvert.DeserializeObject<PlantDictionary>(response);
            return plantData;
        }
    }
}
