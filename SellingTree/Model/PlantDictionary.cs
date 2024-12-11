using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace SellingTree.Model
{
    using Microsoft.UI.Xaml.Controls;
    using Newtonsoft.Json;

    public class PlantDictionary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("common_name")]
        public string CommonName { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("scientific_name")]
        public string ScientificName { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("bibliography")]
        public string Bibliography { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("family_common_name")]
        public string FamilyCommonName { get; set; }

        [JsonProperty("genus_id")]
        public string genus_id { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("genus")]
        public string Genus { get; set; }

        [JsonProperty("family")]
        public string Family { get; set; }

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
        private const string SearchApiUrl = "https://trefle.io/api/v1/plants";

        public PlantService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + ApiKey);
        }

        // Lấy danh sách các cây từ API
        public async Task<List<PlantDictionary>> GetPlantsAsync(int page = 1, string search = "")
        {
            string usingApi = string.IsNullOrEmpty(search) ? ApiUrl : SearchApiUrl;

            string query = string.IsNullOrEmpty(search)
                ? $"?token={ApiKey}&page={page}"
                : $"?token={ApiKey}&filter[common_name]={Uri.EscapeDataString(search)}"; // Đảm bảo mã hóa ký tự đặc biệt

            // Gửi yêu cầu GET
            var response = await _httpClient.GetStringAsync($"{usingApi}{query}");

            // In ra phản hồi từ API để kiểm tra
            Console.WriteLine($"Response: {response}");

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response); // Deserialize thành ApiResponse

            return apiResponse?.Data ?? new List<PlantDictionary>(); // Trả về danh sách Plant từ Data
        }

    }
}
