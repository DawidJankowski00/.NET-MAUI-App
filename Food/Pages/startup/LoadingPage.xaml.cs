using Food.ViewModel;

namespace Food.Pages.startup;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}