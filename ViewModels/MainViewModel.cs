using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fitness.DB;
using Fitness.Models;
using System.Collections.ObjectModel;

namespace Fitness.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        public MainViewModel(FitnessDatabase db)
        {
            _db = db;
            WorkoutDays = new();
            _ = LoadWorkoutDays();
            Exercises = new()
            {
                new ExerciseViewModel
                {
                    Name = "ttttteest",
                    Exercise = new Exercise {
                        Name = "43jt6o234",
                        DefaultInterval = TimeSpan.FromSeconds(20),
                        WorkoutDayId = 1,
                        Description = "tetrwyt2w4yh"
                    }
                }
            };
        }

        private readonly FitnessDatabase _db;
        private WorkoutDay _selectedWorkoutDay;
        private ExerciseViewModel _selectedExercise;
        private ObservableCollection<WorkoutDay> _workoutDays;
        private ObservableCollection<ExerciseViewModel> _exercises;

        public WorkoutDay SelectedWorkoutDay 
        { 
            get => _selectedWorkoutDay; 
            set 
            { 
                SetProperty(ref _selectedWorkoutDay, value);
            }
        }
        public ExerciseViewModel SelectedExercise 
        { 
            get => _selectedExercise; 
            set 
            { 
                SetProperty(ref _selectedExercise, value);
            }
        }

        public ObservableCollection<WorkoutDay> WorkoutDays 
        {
            get => _workoutDays;
            set { SetProperty(ref _workoutDays, value); }
        }
        public ObservableCollection<ExerciseViewModel> Exercises
        {
            get => _exercises;
            set { SetProperty(ref _exercises, value); }
        }

        public string Test
        {
            get => "test";
            
        }

        [RelayCommand(CanExecute=nameof(CanSelectWorkoutDay))]
        private async Task WorkoutDaySelectionChanged()
        {
            Exercises.Clear();
            var exercisesDb = await _db.GetExercisesByWorkoutDayAsync(SelectedWorkoutDay.Id);
            foreach (var exerciseDb in exercisesDb)
            {
                Exercises.Add(new ExerciseViewModel(exerciseDb));
            }
            SelectedExercise = Exercises.FirstOrDefault();  
        }
        private bool CanSelectWorkoutDay => true;

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

        private async Task LoadWorkoutDays()
        {
            WorkoutDays = new ObservableCollection<WorkoutDay>(await _db.GetAsync<WorkoutDay>());
        }
        
    }
}
