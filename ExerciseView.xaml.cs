namespace Fitness;

public partial class ExerciseView : ContentView
{
    private ExerciseViewModel _viewModel => (ExerciseViewModel)BindingContext;


	public static readonly BindableProperty ExerciseProperty = BindableProperty.Create(nameof(Exercise), typeof(Exercise), typeof(ExerciseView));

    public Exercise Exercise
    {
        get => (Exercise)GetValue(ExerciseView.ExerciseProperty);
        set {
            SetValue(ExerciseView.ExerciseProperty, value);
            _viewModel.Exercise = value;
            }
    }

    public ExerciseView()
	{
		InitializeComponent();
	}
}