using Fitness.Models;
using Fitness.ViewModels;

namespace Fitness.Views;

public partial class ExerciseView : ContentView
{
    //private ExerciseViewModel _viewModel => (ExerciseViewModel)BindingContext;


	//public static readonly BindableProperty ExerciseProperty = BindableProperty.Create(nameof(Exercise), typeof(ExerciseViewModel), typeof(ExerciseView));

 //   public ExerciseViewModel Exercise
 //   {
 //       get => (ExerciseViewModel)GetValue(ExerciseProperty);
 //       set {
 //           SetValue(ExerciseProperty, value);
 //           _viewModel = value;
 //           }
 //   }

    public ExerciseView()
	{
		InitializeComponent();
	}
}