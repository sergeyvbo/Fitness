using SQLite;

namespace Fitness.Models
{
    public class WorkoutDay: IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public string Name { get; set; }
    }


    
}
