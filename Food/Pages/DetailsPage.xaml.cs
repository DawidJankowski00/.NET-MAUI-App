using Food.ViewModel;

namespace Food.Pages;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(ProductDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}
}