using Food.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Food.Services
{
    public class ProductService
    {
        HttpClient _httpClient;
        public ProductService()
        {
            _httpClient = new HttpClient();
        }

        List<Product> productList = new ();
        public async Task<List<Product>> GetProducts()
        {
            if (productList?.Count > 0)
                return productList;

            var url = ApiConfig.BaseUrl + "/api/Products";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                productList = await response.Content.ReadFromJsonAsync<List<Product>>();

            }

            return productList;
        }

        public async Task<bool> AddProduct(Product product)
        {

            var response = await _httpClient.PostAsJsonAsync(ApiConfig.BaseUrl + "/api/Products", product);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
