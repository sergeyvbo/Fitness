using CommunityToolkit.Mvvm.ComponentModel;

namespace Fitness
{
    public class Exercise: ObservableObject
    {
        private bool _isExpanded;

        public Exercise(int id, string name, string description, bool isExpanded = false)
        {
            Id = id;
            Name = name;
            Description = description;
            IsExpanded = isExpanded;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsExpanded { get => _isExpanded; set { SetProperty(ref _isExpanded, value); } }
    }
    
}
