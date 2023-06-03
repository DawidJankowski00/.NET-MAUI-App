using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Food.Model;

namespace Food.Services
{
    public class ComponentProductService
    {
        HttpClient _httpClient;
        public ComponentProductService()
        {
            _httpClient = new HttpClient();
        }

        List<ComponentProduct> referencesList = new();
        public async Task<List<ComponentProduct>> GetRelations()
        {
            if (referencesList?.Count > 0)
                return referencesList;

            var url = "https://restapi20230501204309.azurewebsites.net/api/ComponentProducts";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                referencesList = await response.Content.ReadFromJsonAsync<List<ComponentProduct>>();

            }

            return referencesList;
        }


    }
}
