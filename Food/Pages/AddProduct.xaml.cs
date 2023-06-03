using Food.ViewModel;

namespace Food.Pages;

public partial class AddProduct : ContentPage
{
	public AddProduct(AddProductViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}