using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Fitness
{
    public class ExerciseViewModel: ObservableObject
    {
        
		private double _weight = 35;
        private int _rep1 = 10;
        private int _rep2 = 10;
        private int _rep3 = 10;
        private Exercise _exercise;
        private TimeSpan _interval;
		
        public double Weight
		{
			get { return _weight; }
			set { SetProperty(ref _weight, value); }
		}
        public int Rep1
		{
			get { return _rep1; }
            set { SetProperty(ref _rep1, value); }
        }
        public int Rep2
        {
            get { return _rep2; }
            set { SetProperty(ref _rep2, value); }
        }
        public int Rep3
        {
            get { return _rep3; }
            set { SetProperty(ref _rep3, value); }
        }
        public Exercise Exercise
        {
            get { return _exercise; }
            set { SetProperty(ref _exercise, value); }
        }
        public TimeSpan Interval
        {
            get { return _interval; }
            set { SetProperty(ref _interval, value); }
        }
    }
}
