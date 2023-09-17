using Fitness.ViewModels;

namespace Fitness.Views;

public partial class MainPage : ContentPage
{
	readonly MainViewModel _viewModel;
    public MainPage(MainViewModel viewModel)
	{
		BindingContext = _viewModel =  viewModel;	
		try
		{
            InitializeComponent();
        }
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

    }
}

