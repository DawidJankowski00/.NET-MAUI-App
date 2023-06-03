using Food.ViewModel;

namespace Food.Pages.startup;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}