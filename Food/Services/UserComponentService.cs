using Food.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Food.Services
{
    
    public class UserComponentService
    {
        HttpClient _httpClient;
        public UserComponentService()
        {
            _httpClient = new HttpClient();
        }
        List<UserComponent> referencesList = new();
        public async Task<List<UserComponent>> GetRelations()
        {
            if (referencesList?.Count > 0)
                return referencesList;

            var url = "https://restapi20230501204309.azurewebsites.net/api/UserComponents";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                referencesList = await response.Content.ReadFromJsonAsync<List<UserComponent>>();

            }

            return referencesList;
        }
    }

}
