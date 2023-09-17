using Fitness.Models;
using SQLite;

namespace Fitness.DB
{
    public sealed class FitnessDatabase
    {
        private SQLiteAsyncConnection _db;

        public FitnessDatabase()
        {
        }

        async Task Init()
        {
            if (_db is not null) 
            {
                return;
            }

            _db = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            await _db.CreateTableAsync<Exercise>();
            await _db.CreateTableAsync<ExerciseEntry>();
            await _db.CreateTableAsync<WorkoutDay>();

            await SeedData();

        }

        public async Task<int> SaveAsync(IEntity item)
        {
            await Init();
            
            if (item.Id is null)
            {
                return await _db.InsertAsync(item);
            }
            
            return await _db.UpdateAsync(item);
        }

        public async Task<int> SaveAllAsync(IEnumerable<IEntity> items)
        {
            await Init();
            int rowsUpdated = 0;
            foreach (var newItems in items.Where(x=>x.Id is null)) 
            {
                rowsUpdated += await _db.InsertAllAsync(items);
            }
            foreach (var newItems in items.Where(x => x.Id is not null))
            {
                rowsUpdated += await _db.UpdateAllAsync(items);
            }
            return rowsUpdated;
        }

        public async Task<List<T>> GetAsync<T>() where T : IEntity, new()
        {
            await Init();
            return await _db.Table<T>().ToListAsync();
        }

        public async Task<bool> HasAny<T>() where T : IEntity, new()
        {
            await Init();
            return await _db.Table<T>().CountAsync() != 0;
        }

        public async Task<List<Exercise>> GetExercisesByWorkoutDayAsync(int? id)
        {
            await Init();
            return await _db.Table<Exercise>().Where(x => x.WorkoutDayId == id).ToListAsync();
        }

        private async Task SeedData()
        {
            if (!await HasAny<WorkoutDay>())
            {
                List<WorkoutDay> WorkoutDays = new()
                {
                    new WorkoutDay { Name = "Day 1: Chest, Triceps" },
                    new WorkoutDay { Name = "Day 2: Back, Biceps" },
                    new WorkoutDay { Name = "Day 3: Legs, Shoulders" },
                };
                await SaveAllAsync(WorkoutDays);
            }

            if (!await HasAny<Exercise>())
            {
                List<Exercise> Exercises = new()
                {
                    new Exercise { WorkoutDayId=1, Name = "Dumbbell Bench Press", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=1, Name = "Incline Dumbbell Bench Press", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=1, Name = "Crossovers", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=1, Name = "Triceps Push Downs", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=1, Name = "Overhead Triceps Extensions", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=2, Name = "Pull Ups", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=2, Name = "Dumbbell Deadlifts", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=2, Name = "Horizontal Cable Pulls", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=2, Name = "Alt Dumbbell Curls", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=2, Name = "Cable Curls", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=3, Name = "Squats", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=3, Name = "Dumbbell Lunges", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=3, Name = "Dumbbell Military Press", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=3, Name = "Lateral Rises", DefaultInterval = TimeSpan.FromMinutes(2) },
                    new Exercise { WorkoutDayId=3, Name = "Face Pulls", DefaultInterval = TimeSpan.FromMinutes(2) },
                };

                await SaveAllAsync(Exercises);
            }
        }

        
    }
}
