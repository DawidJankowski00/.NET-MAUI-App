using Food.Model;

namespace Food;

public partial class App : Application
{
	public static User User;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
