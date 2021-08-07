using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.Extensions;
using Microsoft.EntityFrameworkCore;
using StreetWorkoutApp.Data;
using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Common;
using StreetWorkoutApp.Services.Equipment;
using StreetWorkoutApp.Services.Exercises.Models;
using StreetWorkoutApp.Services.Identity;

namespace StreetWorkoutApp.Services.Exercises
{
    public class ExercisesService : IExercisesService
    {
        private readonly StreetWorkoutDbContext data;
        private readonly IMapper mapper;
        private readonly IEquipmentService equipmentService;
        private readonly ICommonService commonService;
        private readonly IIdentityService identityService;

        public ExercisesService(
            StreetWorkoutDbContext data, 
            IMapper mapper, 
            IEquipmentService equipmentService,
            ICommonService commonService,
            IIdentityService identityService)
        {
            this.data = data;
            this.mapper = mapper;
            this.equipmentService = equipmentService;
            this.commonService = commonService;
            this.identityService = identityService;
        }

        public async Task<int> CreateExercisee(CreateExerciseServiceModel exercise)
        {
            var exerciseToAdd = this.data.Exercises.FirstOrDefault(x => x.Name == exercise.Name);

            if (exerciseToAdd != null)
            {
                return 0;
            }

            var equipmentNeeded =await this.equipmentService.GetEquipmentByName(
                exercise.Equipment.ToList());

            var muscleGroups = await this.commonService.GetMuscleGroupsByNames(exercise.MuscleGroups.ToList());

            exerciseToAdd = new Exercise
            {
                Name = exercise.Name,
                Description = exercise.Description,
                ImageUrl = exercise.ImageUrl,
                ExampleUrl = exercise.ExampleUrl ?? "",
                ExerciseLevel = exercise.ExerciseLevel,
                MuscleGroups = muscleGroups,
                EquipmentNeeded = equipmentNeeded
            };

            await this.data.Exercises.AddAsync(exerciseToAdd);
            await this.data.SaveChangesAsync();

            return exerciseToAdd.Id;
        }

        public async Task<ExerciseDetailsServiceModel> GetExerciseDetails(int exerciseId)
        {
            var exerciseData = this.data.Exercises.FirstOrDefault(ex => ex.Id == exerciseId);
            data.Entry(exerciseData).Collection(e => e.EquipmentNeeded).Load();
            data.Entry(exerciseData).Collection(e => e.MuscleGroups).Load();

            var exercise = this.mapper.Map<ExerciseDetailsServiceModel>(exerciseData);

            return exercise;
        }

        public async Task<FilteredExercisesServiceResponse> GetFileteredExercises(
            ExerciseFilterServiceModel filters,
            int currentPage,
            int resultsPerPage)
        {
            var exercises = this.data.Exercises.Include(e => e.MuscleGroups).ToList();

            exercises = FilterData(filters, exercises);

            var currentPageExercises = exercises
                .Skip(currentPage * resultsPerPage)
                .Take(resultsPerPage)
                .ToList();

            var result = new FilteredExercisesServiceResponse
            {
                Exercises = this.mapper.Map<ICollection<ExerciseServiseModel>>(currentPageExercises),
                AllExercisesCount = exercises.Count()
            };

            return result;
        }

        private static List<Exercise> FilterData(ExerciseFilterServiceModel filters, List<Exercise> exercises)
        {
            if (!String.IsNullOrWhiteSpace(filters.SearchTerm))
            {
                exercises = exercises
                    .Where(ex => ex.Name
                        .Contains(filters.SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (filters.MyExercises)
            {
                exercises = exercises.Where(ex => ex.Users.Any(u => u.UserName == Environment.UserName)).ToList();
            }

            if (!filters.MuscleGroups.IsNullOrEmpty())
            {
                exercises = exercises.Where(ex => ex.MuscleGroups.Any(mg => filters.MuscleGroups.Contains(mg.Name))).ToList();
            }

            if (filters.ExerciseLevel != 0)
            {
                exercises = exercises.Where(ex => ex.ExerciseLevel == filters.ExerciseLevel).ToList();
            }

            return exercises;
        }

        public async Task<Exercise> GetExerciseByName(string exerciseName)
        {
            var exercise = await this.data.Exercises.Where(x => exerciseName == x.Name).FirstOrDefaultAsync();

            return exercise;
        }
    }
}
