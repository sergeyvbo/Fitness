using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fitness.Models;
using Fitness.Services;
using Fitness.Views;
using System.Collections.ObjectModel;


namespace Fitness.ViewModels
{
    public partial class WorkoutListViewModel : BaseViewModel
    {
        public ObservableCollection<WorkoutDay> WorkoutDays { get; set; }
        

        public WorkoutListViewModel(INavigationService navigationService) : base(navigationService)
        {
            WorkoutDays = new ObservableCollection<WorkoutDay>()
            {
                new WorkoutDay()
                {
                    Id = 1,
                    Name = "day 1"
                },
                new WorkoutDay()
                {
                    Id = 2,
                    Name = "day 2"
                },
                new WorkoutDay()
                {
                    Id = 3,
                    Name = "day 3"
                }
            };
            
        }
        private bool CanStartWorkout => true;

        [RelayCommand(CanExecute = nameof(CanStartWorkout))]
        private async Task StartWorkout(WorkoutDay selectedWorkout)
        {
            await NavigationService.NavigateToAsync(nameof(WorkoutPage), new Dictionary<string, object> { { "Id", selectedWorkout.Id } });
        }
    }
}
