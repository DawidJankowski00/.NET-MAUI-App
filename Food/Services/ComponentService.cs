using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Food.Model;

namespace Food.Services
{
    public class ComponentService
    {
        HttpClient _httpClient;
        public ComponentService()
        {
            _httpClient = new HttpClient();
        }

        List<Component> componentList = new();
        public async Task<List<Component>> GetComponents()
        {
            if (componentList?.Count > 0)
                return componentList;

            var url = "https://restapi20230501204309.azurewebsites.net/api/Components";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                componentList = await response.Content.ReadFromJsonAsync<List<Component>>();

            }

            return componentList;
        }

        public async Task<Component> GetComponent(int id)
        {
            Component component = new();

            var url = "https://restapi20230501204309.azurewebsites.net/api/Components/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                component = await response.Content.ReadFromJsonAsync<Component>();

            }

            return component;
        }
    }
}
