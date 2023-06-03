using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Food.Pages;
using Food.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Services;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Food.Pages.startup;
using Isopoh.Cryptography.Argon2;

namespace Food.ViewModel
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;
        UserService userService = new UserService();
        ComponentService componentService = new ComponentService();
        UserComponentService userComponentService = new UserComponentService();

        [RelayCommand]
        async void Login()
        {
            if (IsBusy) { return; }
            if (string.IsNullOrWhiteSpace(Email) && string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error!", $"Pola są puste", "OK");
                return;
            }
            try
            {
                
                IsBusy = true;
                var users = await userService.GetUsers();
                if(users == null) { return; }
                foreach (var user in users )
                {
                    if(Argon2.Verify(user.Email, Email) && Argon2.Verify(user.Password, Password))
                    {
                        
                        if (Preferences.ContainsKey(nameof(App.User)))
                        {
                            Preferences.Remove(nameof(App.User));
                        }
                        var relations = await userComponentService.GetRelations();
                        foreach (var rel in relations)
                        {
                            if (user.Id == rel.UserId)
                            {
                                var component = await componentService.GetComponent(rel.ComponentId);
                                if (component != null)
                                {
                                    user.BadComponents = new();
                                    user.BadComponents.Add(component);
                                }
                            }
                        }
                        user.Email = Email;
                        string UserStr = JsonConvert.SerializeObject(user);
                        Preferences.Set(nameof(App.User),UserStr);

                        

                        App.User = user;
                        await Shell.Current.GoToAsync($"{nameof(MainPage)}");
                        return;
                    }
                    
                }
                await Shell.Current.DisplayAlert("Error!", "Niepoprawne dane", "OK");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to Login: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        [RelayCommand]
        async void GoToRegister() 
        {
            if (IsBusy) { return; }
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");

        }
    }
}
