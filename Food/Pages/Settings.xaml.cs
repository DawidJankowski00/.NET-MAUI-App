using Food.ViewModel;
using System.Collections.ObjectModel;
using Food.Model;

namespace Food.Pages;

public partial class Settings : ContentPage
{

    public Settings(SettingsViewModel viewModel)
	{
        InitializeComponent();
        BindingContext= viewModel;
    }
}