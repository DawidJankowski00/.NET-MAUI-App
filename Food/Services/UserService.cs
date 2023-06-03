using Food.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;

namespace Food.Services
{
    public class UserService
    {
        HttpClient _httpClient;
        
        public UserService()
        {
            _httpClient = new HttpClient();
        }

        List<User> userList = new();
        public async Task<List<User>> GetUsers()
        {
            var url = "https://restapi20230501204309.azurewebsites.net/api/Users";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                userList = await response.Content.ReadFromJsonAsync<List<User>>();

            }
            return userList;
        }

        public async Task<bool> AddUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("https://restapi20230501204309.azurewebsites.net/api/Users", user);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
