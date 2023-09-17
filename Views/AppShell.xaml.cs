namespace Fitness.Views;

public partial class AppShell : Shell
{
	public AppShell(LoginPage loginPage)
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		shellContent.Content = loginPage;
	}
}
