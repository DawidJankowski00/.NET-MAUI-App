namespace Food.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

		if(App.User != null)
		{
			lblUserEmail.Text = App.User.Email;
			lblUserName.Text = App.User.Name;
		}
	}
}