using Fitness.ViewModels;

namespace Fitness.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginFormViewModel loginFormViewModel)
	{
		InitializeComponent();
        loginPage.BindingContext = loginFormViewModel;
    }
}