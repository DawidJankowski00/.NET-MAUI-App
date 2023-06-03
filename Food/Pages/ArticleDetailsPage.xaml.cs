using Food.ViewModel;

namespace Food.Pages;

public partial class ArticleDetailsPage : ContentPage
{
	public ArticleDetailsPage(ArticleDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext= viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}