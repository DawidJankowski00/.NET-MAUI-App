using Food.Pages.startup;
using Food.Pages;
using Food.Services;
using Food.ViewModel;

namespace Food;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);
        builder.Services.AddSingleton<LoadingPageViewModel>();
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<RegisterViewModel>();
        builder.Services.AddSingleton<RegisterPage>();
        builder.Services.AddSingleton<ArticleViewModel>();
        builder.Services.AddSingleton<ArticleService>();
        builder.Services.AddSingleton<ProductService>();
        builder.Services.AddSingleton<ProductViewModel>();
		builder.Services.AddSingleton<ProductDetailsViewModel>();
        builder.Services.AddSingleton<ArticleDetailsViewModel>();
        builder.Services.AddSingleton<ArticleDetailsPage>();
        builder.Services.AddSingleton<Products>();
        builder.Services.AddSingleton<DetailsPage>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<Settings>();
        builder.Services.AddSingleton<SettingsViewModel>();
        builder.Services.AddSingleton<AddComponent>();
        builder.Services.AddSingleton<AddComponentViewModel>();
        builder.Services.AddSingleton<AddProduct>();
        builder.Services.AddSingleton<AddProductViewModel>();

        return builder.Build();
	}
}
