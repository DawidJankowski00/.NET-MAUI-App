using Food.Model;
using Food.ViewModel;

namespace Food.Pages;

public partial class AddComponent : ContentPage
{
	public AddComponent(AddComponentViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}