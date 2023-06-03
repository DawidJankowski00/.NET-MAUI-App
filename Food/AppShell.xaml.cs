using Food.Pages;
using Food.Pages.startup;
using Food.ViewModel;

namespace Food;

public partial class AppShell : Shell
{
	public AppShell()
	{
        InitializeComponent();
        BindingContext = new AppShellViewModel();
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(ArticleDetailsPage), typeof(ArticleDetailsPage));
        Routing.RegisterRoute(nameof(AddComponent), typeof(AddComponent));
        Routing.RegisterRoute(nameof(AddProduct), typeof(AddProduct));
    }
}
