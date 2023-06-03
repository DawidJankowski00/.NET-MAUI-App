using Food.Pages;
using Food.Controls;
using Food.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Food.ViewModel
{
    public partial class LoadingPageViewModel
    {
        public LoadingPageViewModel() 
        {
            CheckUserLogin();
        }
        private async void CheckUserLogin()
        {
            string userStr = Preferences.Get(nameof(App.User), "");
            if (string.IsNullOrWhiteSpace(userStr)) 
            {
                await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(userStr);
                App.User = user;
                Shell.Current.FlyoutHeader = new FlyoutHeaderControl();
                await Shell.Current.GoToAsync($"{nameof(MainPage)}");
            }
        }
    }
}
