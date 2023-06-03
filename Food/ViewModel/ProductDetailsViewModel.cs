using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Food.Model;
using Microsoft.Maui.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.ViewModel
{
    [QueryProperty("Product","Product")]
    public partial class ProductDetailsViewModel : BaseViewModel
    {
        IMap map;
        public ProductDetailsViewModel(IMap map)
        {
            this.map = map;
        }

        [ObservableProperty]
        Product product;

        [RelayCommand]
        async Task OpenMapAsync()
        {
            var placemark = new Placemark
            {
                Thoroughfare = Product.Location
                
            };
            var options = new MapLaunchOptions { Name = Product.Location };

            try
            {
                await map.OpenAsync(placemark, options);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to open map: {ex.Message}", "OK");
            }
        }


    }
}
