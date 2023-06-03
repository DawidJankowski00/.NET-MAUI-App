using Food.ViewModel;

namespace Food.Pages;

public partial class Products : ContentPage
{
	public Products(ProductViewModel viewModel)
	{
		InitializeComponent();
		
		BindingContext = viewModel;
	}
}