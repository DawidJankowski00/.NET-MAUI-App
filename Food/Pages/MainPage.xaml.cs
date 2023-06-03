using Food.ViewModel;

namespace Food.Pages;

public partial class MainPage : ContentPage
{

	public MainPage(ArticleViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;
    }
}

