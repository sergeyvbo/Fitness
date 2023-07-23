using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Fitness
{
    public partial class MainViewModel: ObservableObject
    {
        private WorkoutType _selectedWorkoutType;
        private Exercise _selectedExercise;
        private ObservableCollection<WorkoutType> _workoutTypes;
        private ObservableCollection<Exercise> _exercises;

        public WorkoutType SelectedWorkoutType 
        { 
            get => _selectedWorkoutType;
            set { SetProperty(ref _selectedWorkoutType, value); }
        }
        public Exercise SelectedExercise 
        { 
            get => _selectedExercise; 
            set { SetProperty(ref _selectedExercise, value); }
        }

        public ObservableCollection<WorkoutType> WorkoutTypes
        {
            get => _workoutTypes;
            set { SetProperty(ref _workoutTypes, value); }
        }
        public ObservableCollection<Exercise> Exercises
        {
            get => _exercises;
            set { SetProperty(ref _exercises, value); }
        }

        [RelayCommand(CanExecute=nameof(CanSelectWorkoutType))]
        private void WorkoutTypeSelectionChanged()
        {
            CreateExercises(SelectedWorkoutType);
            SelectedExercise = Exercises.First();
        }
        private bool CanSelectWorkoutType => true;

        [RelayCommand(CanExecute = nameof(CanPressNext))]
        private void Next()
        {
            SelectedExercise.IsExpanded = false;
            var selectedIndex = Exercises.IndexOf(SelectedExercise);
            if (selectedIndex == Exercises.Count - 1)
            {
                SaveWorkout();
            } else
            {
                SelectedExercise = Exercises[selectedIndex + 1];
            }
            SelectedExercise.IsExpanded = true;
        }
        private bool CanPressNext => true;

        private void SaveWorkout()
        {

        }

        private void CreateExercises(WorkoutType selectedWorkoutType)
        {
            if (selectedWorkoutType.Id == 1) {
                Exercises = new()
                {
                    new(1, "Dumbbell Bench Press", "Horizontal Dumbbell Push description", true),
                    new(2, "Incline Dumbbell Push", "Incline Dumbbell Push description"),
                    new(3, "Crossover Cable Push", "Crossover Cable Push description"),
                };
            } else if (selectedWorkoutType.Id == 2)
            {
                Exercises = new()
                {
                    new(1, "Pull ups", "horizontal bar pull ups", true),
                    new(2, "Dumbbell Dead Lifts", "dead lift description"),
                    new(3, "One arm high cable row", "description"),
                };
            } else if (selectedWorkoutType.Id == 3)
            {
                Exercises = new()
                {
                    new(1, "squats", "horizontal bar pull ups", true),
                    new(2, "lateral dumbbell raise", "dead lift description"),
                    new(3, "face pulls", "description"),
                };
            }
        }

        public MainViewModel()
        {
            WorkoutTypes = new()
            {
                new(1, "Day 1: Chest, Triceps"),
                new(2, "Day 2: Back, Biceps"),
                new(3, "Day 3: Legs, Shoulders")
            };

            Exercises = new();
        }
    }
}
