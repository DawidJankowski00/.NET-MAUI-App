using Food.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Food.Services
{
    public class ArticleService
    {
        HttpClient _httpClient;
        public ArticleService()
        {
            _httpClient = new HttpClient();
        }

        List<Article> productList = new();
        public async Task<List<Article>> GetProducts()
        {
            if (productList?.Count > 0)
                return productList;

            var url = ApiConfig.BaseUrl + "/api/Articles";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                productList = await response.Content.ReadFromJsonAsync<List<Article>>();

            }

            return productList;
        }
    }
}
