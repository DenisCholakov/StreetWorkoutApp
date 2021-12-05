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
using StreetWorkoutApp.Server.Infrastructure;

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

        public ActionResult<ExerciseDetailsModel> GetExerciseDetails(int exerciseId)
        {
            var exercise = this.exercisesService.GetExerciseDetails(exerciseId);

            var result = this.mapper.Map<ExerciseDetailsModel>(exercise);

            return Ok(result);
            
        }

        [HttpGet("all/names")]
        [SwaggerOperation(
            Summary = "Get the names of all existing exercises",
            Description = "Get the names of all existing exercises",
            OperationId = "GetExerciseDetails")]

        public ActionResult<ExerciseDetailsModel> GetAllExerciseNames(int exerciseId)
        {
            var exerciseNames = this.exercisesService.GetAllExerciseNames();

            return Ok(exerciseNames);
        }

        [HttpPost("add")]
        [SwaggerOperation(
            Summary = "Create exercise",
            Description = "Creates a new exercise",
            OperationId = "CreateExercise")]

        public async Task<ActionResult<int>> CreateExerciseAsync(CreateExerciseFormModel exercise)
        {
            var exerciseToCreate = this.mapper.Map<CreateExerciseServiceModel>(exercise);

            var createdExerciseId = await this.exercisesService.CreateExerciseAsync(exerciseToCreate, this.User.GetId());

            if (createdExerciseId == -1)
            {
                return Conflict("The exercise you want to create already exists.");
            }

            return Created("", createdExerciseId);
        }

        [HttpPut("edit/{exerciseId}")]
        [SwaggerOperation(
            Summary = "Edit existing exercise",
            Description = "Edit an existing exercise",
            OperationId = "EditExercsieAsync")]

        public async Task<ActionResult<int>> EditExercsieAsync(CreateExerciseFormModel exercise, int exerciseId)
        {
            var editModel = this.mapper.Map<CreateExerciseServiceModel>(exercise);

            var createdExerciseId = await this.exercisesService.EditExerciseAsync(editModel, exerciseId, this.User.GetId());

            if (createdExerciseId == -1)
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

        public ActionResult<FilteredExercisesResponse> GetFileteredExercises(
            [FromQuery][Required] int currentPage,
            [FromQuery][Required] int resultsPerPage,
            [FromBody] ExerciseFiltersModel filters)
        {
            var serviceFilters = this.mapper.Map<ExerciseFilterServiceModel>(filters);

            var exercises = this.exercisesService
                .GetFileteredExercises(serviceFilters, currentPage, resultsPerPage);

            var result = this.mapper.Map<FilteredExercisesResponse>(exercises);

            return Ok(result);
        }

        [HttpDelete("delete/{exerciseId}")]
        [SwaggerOperation(
            Summary = "Deletes an exercise",
            Description = "Deletes an exercise created by the logged trainer. Also the admin can delete every exercise",
            OperationId = "DeleteExercise")]

        public async Task<ActionResult<bool>> DeleteExerciseAsync(int exerciseId)
        {

            var isDeleted = await this.exercisesService.DeleteExerciseAsync(exerciseId, this.User.GetId());

            if (!isDeleted)
            {
                return Conflict("The exercise you want to Delete was not found!");
            }

            return Ok();
        }
    }
}
