using Fitness.ViewModels;

namespace Fitness.Views;

public partial class WorkoutList : ContentPage
{
	readonly WorkoutListViewModel _viewModel;


	public WorkoutList(WorkoutListViewModel viewModel)
	{
		BindingContext = _viewModel = viewModel;
		InitializeComponent();
	}
}