﻿using System.Collections.Generic;
using System.Threading.Tasks;

using StreetWorkoutApp.Services.Exercises.Models;

namespace StreetWorkoutApp.Services.Exercises
{
    public interface IExercisesService
    {
        Task<int> CreateExercisee(CreateExerciseServiceModel exercise);

        Task<ExerciseDetailsServiceModel> GetExerciseDetails(int exerciseId);

        Task<FilteredExercisesServiceResponse> GetFileteredExercises(
            ExerciseFilterServiceModel filters,
            int currentPage,
            int resultsPerPage);
    }
}
