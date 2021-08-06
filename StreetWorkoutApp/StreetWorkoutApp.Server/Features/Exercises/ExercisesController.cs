using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;


using StreetWorkoutApp.Server.Features.Exercises.Models;
using StreetWorkoutApp.Services.Exercises;
using StreetWorkoutApp.Services.Exercises.Models;
using System.ComponentModel.DataAnnotations;

namespace StreetWorkoutApp.Server.Features.Exercises
{
    [Authorize]
    public class ExercisesController : ApiController
    {
        private readonly IExercisesService exercisesService;
        private readonly IMapper mapper;

        public ExercisesController(IExercisesService exercisesService, IMapper mapper)
        {
            this.exercisesService = exercisesService;
            this.mapper = mapper;
        }


        [HttpGet("details/{exerciseId}")]
        [SwaggerOperation(
            Summary = "Get Details for the selected exercise",
            Description = "Gets Details for the selected exercise",
            OperationId = "GetExerciseDetails")]

        public async Task<ActionResult<ExerciseDetailsModel>> GetExerciseDetails(int exerciseId)
        {
            var exercise = await this.exercisesService.GetExerciseDetails(exerciseId);

            var result = this.mapper.Map<ExerciseDetailsModel>(exercise);

            return Ok(result);
            
        }

        [HttpPost("add")]
        [SwaggerOperation(
            Summary = "Create exercise",
            Description = "Creates a new exercise",
            OperationId = "AddExercise")]

        public async Task<ActionResult<int>> CreateExercise([FromBody] CreateExerciseFormModel exercise)
        {
            var exerciseToCreate = this.mapper.Map<CreateExerciseServiceModel>(exercise);

            var createdExerciseId = await this.exercisesService.CreateExercisee(exerciseToCreate);

            if (createdExerciseId == 0)
            {
                return Conflict("The exercise you want to create already exists.");
            }

            return Created("", createdExerciseId);
        }

        [HttpPost("filter")]
        [SwaggerOperation(
            Summary = "Get Filtered Exercises",
            Description = "Get Filtered Exercises",
            OperationId = "GetFileteredExercises")]

        public async Task<ActionResult<FilteredExercisesResponse>> GetFileteredExercises(
            [FromQuery][Required] int currentPage,
            [FromQuery][Required] int resultsPerPage,
            [FromBody] ExerciseFiltersModel filters)
        {
            var serviceFilters = this.mapper.Map<ExerciseFilterServiceModel>(filters);

            var exercises = await this.exercisesService
                .GetFileteredExercises(serviceFilters, currentPage, resultsPerPage);

            var result = this.mapper.Map<FilteredExercisesResponse>(exercises);

            return Ok(result);
        }
    }
}
