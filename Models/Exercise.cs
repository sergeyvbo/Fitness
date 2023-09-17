using SQLite;

namespace Fitness.Models
{
    public class Exercise: IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WorkoutDayId { get; set; }
        public TimeSpan DefaultInterval { get; set; }
    }
}
