using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Food.Model;
using Food.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.ViewModel
{
    public partial class AddProductViewModel: BaseViewModel
    {
        ProductService productService = new();
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _description;
        [ObservableProperty]
        private string _productType;
        [ObservableProperty]
        private string _image;
        [ObservableProperty]
        private string _location;
        [ObservableProperty]
        private double _calories;
        [ObservableProperty]
        private double _fat;
        [ObservableProperty]
        private double _carbohydrates;
        [ObservableProperty]
        private double _sugar;
        [ObservableProperty]
        private double _fiber;
        [ObservableProperty]
        private double _protein;
        [ObservableProperty]
        private double _salt;

        public AddProductViewModel() {
        
        }

        [RelayCommand]
        async void AddProduct()
        {
            
            if (_name == null)
            {
                await Shell.Current.DisplayAlert("Error!", $"Uzupełnij dane", "OK");
                return;
            }
            else
            {
                Product product = new();
                product.Name = _name;
                product.Description = _description;
                product.Location = _location;
                product.Calories = _calories;
                product.Fat = _fat;
                product.Carbohydrates = _carbohydrates;
                product.Sugar = _sugar;
                product.Fiber = _fiber;
                product.Protein = _protein;
                product.Salt = _salt;
                product.Image = _image;
                product.ProductType = _productType;
                if (App.User.Type == "Admin" || App.User.Type == "Moderator")
                {
                    
                    var result = await productService.AddProduct(product);
                    
                }
                
                await Shell.Current.DisplayAlert("Udane!", $"Dodano pomyślnie", "OK");
            }
        }
    }
}
