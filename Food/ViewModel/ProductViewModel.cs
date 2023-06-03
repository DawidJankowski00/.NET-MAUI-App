using Food.Model;
using System.Collections.ObjectModel;
using Food.Services;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using Food.Pages;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Food.ViewModel
{
    public partial class ProductViewModel : BaseViewModel
    {
        ProductService productService;
        ComponentService componentService;
        ComponentProductService componentProductService;
        public ObservableCollection<Product> Products { get; } = new();

        IConnectivity connectivity;
        public ProductViewModel(ProductService productService, IConnectivity connectivity)
        {
            Title = "Produkty";
            this.productService = productService;
            this.componentProductService= new();
            this.componentService= new();
            this.connectivity = connectivity;
            _ = GetProductAsync();
        }

        [RelayCommand]
        async Task GoToDetailAsync(Product product)
        {
            if(product is null) { return; }

            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"Product",product }
                });
        }

        [RelayCommand]
        async Task GoToAddProductAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddProduct)}");
        }


        [ObservableProperty]
        private string _SearchName;
         
        [RelayCommand]
        async Task GetProductAsync()
        {
            if (IsBusy) { return; }
            try
            {
                if(connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Brak połączenia z internetem!", $"Sprawdź polaczenie internetowe i spróbuj ponownie ", "OK");
                    return;
                }

                IsBusy = true;

                var components = await componentService.GetComponents();
                var products = await productService.GetProducts();
                var relations = await componentProductService.GetRelations();


                foreach (Product p in products)
                {
                    List<Component> Components = new();
                    foreach (Component cp in components)
                    {
                        foreach (ComponentProduct rel in relations)
                        {

                            if (p.Id == rel.ProductId)
                            {
                                if (cp.Id == rel.ComponentId)
                                {
                                    Components.Add(cp);
                                }
                            }

                        }
                    }
                    p.Components = Components;
                }

                if (Products.Count != 0)
                {
                    Products.Clear();
                }
                foreach(Product product in products)
                {
                    if (product.Components != null)
                    {
                        foreach (Component component in product.Components)
                        {

                            component._Color = 0;

                        }
                    }
                    if (SearchName != null)
                    {
                        if (product.Name.ToLower().Contains(SearchName.ToLower()))
                        {
                            if (product.Components != null)
                            {
                                if (App.User != null)
                                {

                                    foreach (Component comp in App.User.BadComponents)
                                    {
                                        foreach (Component component in product.Components)
                                        {

                                            if (comp.Name.ToLower() == component.Name.ToLower())
                                            {
                                                component._Color = 1;
                                            }
                                        }
                                    }
                                }
                            }
                            
                            Products.Add(product);
                        }
                            
                            
                    }
                    else
                    {
                        if (product.Components != null)
                        {
                            if (App.User != null)
                            {
                                if (App.User.BadComponents != null){
                                    foreach (Component comp in App.User.BadComponents)
                                    {
                                        foreach (Component component in product.Components)
                                        {

                                            if (comp.Name.ToLower() == component.Name.ToLower())
                                            {
                                                component._Color = 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Products.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get products: {ex.Message}","OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
