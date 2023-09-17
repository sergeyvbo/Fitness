using CommunityToolkit.Mvvm.ComponentModel;
using Fitness.Models;

namespace Fitness.ViewModels
{
    public class WorkoutViewModel : ObservableObject
    {
        private WorkoutDay _workoutDay;

        public WorkoutDay WorkoutDay
        {
            get => _workoutDay;
            set
            {
                SetProperty(ref _workoutDay, value);
            }
        }
    }
}
