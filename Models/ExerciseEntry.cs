using SQLite;

namespace Fitness.Models
{
    public class ExerciseEntry
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public int ExerciseId { get; set; }

        public DateTime Date { get; set; }
        public double Weight1 { get; set; }
        public double Weight2 { get; set; }
        public double Weight3 { get; set; }

        public int Rep1 { get; set; }
        public int Rep2 { get; set; }
        public int Rep3 { get; set; }
    }


    
}
