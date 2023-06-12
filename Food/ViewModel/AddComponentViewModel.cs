using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Food.Model;
using Food.Services;

namespace Food.ViewModel
{
    public partial class AddComponentViewModel: BaseViewModel
    {
        ComponentService componentService = new();
        UserComponentService userComponentService = new();
        public ObservableCollection<Model.Component> Components { get; set; } = new();
        IConnectivity connectivity;
        public AddComponentViewModel(IConnectivity connectivity) 
        {
            this.connectivity = connectivity;
            _ = GetComponentAsync();
        }


        [RelayCommand]
        async Task GetComponentAsync()
        {
            if (IsBusy) { return; }
            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Brak połączenia z internetem!", $"Sprawdź polaczenie internetowe i spróbuj ponownie ", "OK");
                    return;
                }
                Components.Clear();
                IsBusy = true;
                var components = await componentService.GetComponents();


                var activeComponents = App.User.BadComponents;
                foreach (Model.Component component in components)
                {
                    Components.Add(component);

                }
                if (activeComponents != null)
                {
                    foreach (Model.Component component in Components)
                    {
                        if (activeComponents.Contains(component))
                        {
                            Components.Remove(component);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get components: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task AddThis(Model.Component component)
        {
            try
            {
                if(component is null)
                {
                    return;
                }
                if (App.User.BadComponents == null)
                {
                    List<Model.Component> tmp = new();
                    tmp.Add(component);
                    App.User.BadComponents = tmp;

                }
                else
                {
                    App.User.BadComponents.Add(component);
                }

                UserComponent rel = new();
                rel.UserId = App.User.Id;
                rel.ComponentId = component.Id;

                await userComponentService.AddUserComponent(rel);
                _ = GetComponentAsync();
                await Shell.Current.DisplayAlert("Dodano", $"", "OK");
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Nie mozna dodac tego skladnika: {ex.Message}", "OK");
            }
        }
    }
}
