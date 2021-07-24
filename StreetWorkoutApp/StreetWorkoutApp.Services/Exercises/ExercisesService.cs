using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StreetWorkoutApp.Data;
using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Exercises.Models;

namespace StreetWorkoutApp.Services.Exercises
{
    public class ExercisesService : IExercisesService
    {
        private readonly StreetWorkoutDbContext data;
        private readonly IMapper mapper;

        public ExercisesService(StreetWorkoutDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<ExerciseDetailsServiceModel> CreateExercisee(CreateExerciseServiceModel exercise)
        {
            var exerciseToAdd = this.data.Exercises.FirstOrDefault(x => x.Name == exercise.Name);

            if (exerciseToAdd != null)
            {
                return null;
            }

            exerciseToAdd = new Exercise
            {
                Name = exercise.Name,
                ExampleUrl = exercise.ExampleUrl ?? "",
                ImageUrl = exercise.ImageUrl ?? "",
                ExerciseLevel = exercise.ExerciseLevel,
                MuscleGroups = exercise.MuscleGroups,
                EquipmentNeeded = exercise.EquipmentNeeded
            };

            await this.data.Exercises.AddAsync(exerciseToAdd);
            await this.data.SaveChangesAsync();

            var result = this.mapper.Map<ExerciseDetailsServiceModel>(exerciseToAdd);

            return result;
        }

        public async Task<ExerciseDetailsServiceModel> GetExerciseDetails(int exerciseId)
        {
            var exerciseData = this.data.Exercises.FirstOrDefault(ex => ex.Id == exerciseId);

            var exercise = this.mapper.Map<ExerciseDetailsServiceModel>(exerciseData);

            return exercise;
        }
    }
}
