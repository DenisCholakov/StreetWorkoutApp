using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using IdentityServer4.Extensions;

using StreetWorkoutApp.Data;
using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Common;
using StreetWorkoutApp.Services.Equipment;
using StreetWorkoutApp.Services.Exercises.Models;

namespace StreetWorkoutApp.Services.Exercises
{
    public class ExercisesService : IExercisesService
    {
        private readonly StreetWorkoutDbContext data;
        private readonly IMapper mapper;
        private readonly IEquipmentService equipmentService;
        private readonly ICommonService commonService;

        public ExercisesService(
            StreetWorkoutDbContext data, 
            IMapper mapper, 
            IEquipmentService equipmentService,
            ICommonService commonService)
        {
            this.data = data;
            this.mapper = mapper;
            this.equipmentService = equipmentService;
            this.commonService = commonService;
        }

        public async Task<int> CreateExerciseAsync(CreateExerciseServiceModel exercise, string userId)
        {
            var exerciseToAdd = this.data.Exercises.FirstOrDefault(x => x.Name == exercise.Name);

            if (exerciseToAdd != null)
            {
                return -1;
            }

            var equipmentNeeded = this.equipmentService.GetEquipmentByName(
                exercise.Equipment.ToList());

            var muscleGroups = this.commonService.GetMuscleGroupsByNames(exercise.MuscleGroups.ToList());

            var creator = this.data.Trainers.FirstOrDefault(t => t.UserId == userId);

            if (creator == null)
            {
                throw new Exception("The user trying to create the training is not a trainer!");
            }

            exerciseToAdd = new Exercise
            {
                Name = exercise.Name,
                Description = exercise.Description,
                ImageUrl = exercise.ImageUrl,
                ExampleUrl = exercise.ExampleUrl ?? "",
                Creator = creator,
                ExerciseLevel = exercise.ExerciseLevel,
                MuscleGroups = muscleGroups,
                EquipmentNeeded = equipmentNeeded
            };

            await this.data.Exercises.AddAsync(exerciseToAdd);
            await this.data.SaveChangesAsync();

            return exerciseToAdd.Id;
        }


        public async Task<int> EditExerciseAsync(CreateExerciseServiceModel model, int exerciseId, string userId)
        {
            var exercsie = await this.data.Exercises.FirstOrDefaultAsync(x => x.Id == exerciseId);

            if (exercsie == null)
            {
                throw new InvalidOperationException("The exercise you want to edit, does not exist.");
            }

            var trainer = await this.data.Trainers.FirstOrDefaultAsync(x => x.UserId == userId);

            if (trainer == null || exercsie.CreatorId != trainer.Id)
            {
                throw new InvalidOperationException("Sorry, but you are not allowed to edit this exercsie.");
            }

            exercsie.Name = model.Name;
            exercsie.Description = model.Description;
            exercsie.ExerciseLevel = model.ExerciseLevel;
            exercsie.ExampleUrl = model.ExampleUrl;
            exercsie.ImageUrl = model.ImageUrl;
            exercsie.MuscleGroups = this.commonService.GetMuscleGroupsByNames(model.MuscleGroups.ToList());

            this.EditEquipment(exercsie, model.Equipment);

            await this.data.SaveChangesAsync();

            return exercsie.Id;
        }

        public async Task<bool> DeleteExerciseAsync(int exerciseId, string userId)
        {
            var trainer = await this.data.Trainers.FirstOrDefaultAsync(t => t.UserId == userId);
            var exerciseToDelete = this.data.Exercises.FirstOrDefault(e => e.Id == exerciseId);

            if (trainer == null || trainer.Id != exerciseToDelete.CreatorId)
            {
                throw new InvalidOperationException("The user that is trying to delete this training does not have the rights to do it.");
            }            

            if (exerciseToDelete == null)
            {
                return false;
            }

            var trainingsIncludedIn = this.data.Trainings
                .Select(t => t.Exercises)
                .Where(t => t.Any(te => te.ExerciseId == exerciseId))
                .ToList();

            foreach (var trainingExercises in trainingsIncludedIn)
            {
                var toRemove = trainingExercises.FirstOrDefault(te => te.ExerciseId == exerciseId);
                trainingExercises.Remove(toRemove);
            }

            var equipmentUsedForexercise = this.data.Equipments
                .Include(e => e.Exercises)
                .Where(e => e.Exercises.Contains(exerciseToDelete)).ToList();

            foreach (var equipment in equipmentUsedForexercise)
            {
                equipment.Exercises.Remove(exerciseToDelete);
            }

            this.data.Exercises.Remove(exerciseToDelete);
            await this.data.SaveChangesAsync();

            return true;
        }

        public ExerciseDetailsServiceModel GetExerciseDetails(int exerciseId)
        {
            var exerciseData = this.data.Exercises.FirstOrDefault(ex => ex.Id == exerciseId);
            data.Entry(exerciseData).Collection(e => e.EquipmentNeeded).Load();
            data.Entry(exerciseData).Collection(e => e.MuscleGroups).Load();

            var exercise = this.mapper.Map<ExerciseDetailsServiceModel>(exerciseData);

            return exercise;
        }

        public FilteredExercisesServiceResponse GetFileteredExercises(
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


        public async Task<Exercise> GetExerciseByNameAsync(string exerciseName)
        {
            var exercise = await this.data.Exercises.Where(x => exerciseName == x.Name).FirstOrDefaultAsync();

            return exercise;
        }

        public ICollection<string> GetAllExerciseNames()
        {
            var exerciseNames = this.data.Exercises.Select(e => e.Name).ToList();

            return exerciseNames;
        }

        private void EditEquipment(Exercise exercise, ICollection<string> modelEquipment)
        {
            var equipmentToAdd = this.equipmentService.AddEquipmentToTraining(exercise, modelEquipment);

            foreach (var equipment in exercise.EquipmentNeeded)
            {
                if (!equipmentToAdd.Contains(equipment))
                {
                    exercise.EquipmentNeeded.Remove(equipment);
                }
            }
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
                exercises = exercises.Where(ex => ex.BookmarkedUsers.Any(u => u.UserName == Environment.UserName)).ToList();
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
    }
}
