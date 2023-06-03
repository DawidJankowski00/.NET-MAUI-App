using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Food.Model;
using Food.Pages;

namespace Food.ViewModel
{
    public partial class SettingsViewModel :BaseViewModel
    {
        public ObservableCollection<Component> Components { get; } = new();
        public SettingsViewModel()
        {
            var cmp = App.User.BadComponents;
            if (cmp != null) {
                foreach (Component c in cmp)
                {
                    Components.Add(c);
                }
            }
        }

        [RelayCommand]
        async Task RrAsync()
        {
            Components.Clear();
            var cmp = App.User.BadComponents;
            if (cmp != null)
            {
                foreach (Component c in cmp)
                {
                    Components.Add(c);
                }
            }
        }

        [RelayCommand]
        async Task GoToAddAsync(Article article)
        {
            try
            {

                await Shell.Current.GoToAsync($"{nameof(AddComponent)}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get components: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        async Task DelThis(Component component)
        {
            try
            {
                if (component is null)
                {
                    return;
                }
                App.User.BadComponents.Remove(component);
                await Shell.Current.DisplayAlert("Usunieto", $"", "OK");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Nie mozna usunąć tego skladnika: {ex.Message}", "OK");
            }
        }
    }
}
