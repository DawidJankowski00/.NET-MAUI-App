using CommunityToolkit.Mvvm.Input;
using Food.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.ViewModel
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [RelayCommand]
        async void SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.User))) 
            {
                Preferences.Remove(nameof(App.User));
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

    }
}
