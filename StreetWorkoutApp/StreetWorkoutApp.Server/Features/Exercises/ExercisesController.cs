using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


using StreetWorkoutApp.Server.Features.Exercises.Models;
using StreetWorkoutApp.Services.Exercises;
using StreetWorkoutApp.Services.Exercises.Models;
using Microsoft.AspNetCore.Authorization;

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


        [HttpGet("exercise-details/{exerciseId}")]
        [SwaggerOperation(
            Summary = "Get Details for the selected exercise",
            Description = "Gets Details for the selected exercise",
            OperationId = "GetExerciseDetails")]

        public async Task<ActionResult<ExerciseDetailsModel>> GetExerciseDetails([FromQuery] int exerciseId)
        {
            var exercise = await this.exercisesService.GetExerciseDetails(exerciseId);

            var result = this.mapper.Map<ExerciseDetailsModel>(exercise);

            return Ok(result);
            
        }

        [HttpPost("add-exercise")]
        [SwaggerOperation(
            Summary = "Create exercise",
            Description = "Creates a new exercise",
            OperationId = "AddExercise")]

        public async Task<ActionResult<ExerciseDetailsModel>> CreateExercise([FromBody] CreateExerciseFormModel exercise)
        {
            var exerciseToCreate = this.mapper.Map<CreateExerciseServiceModel>(exercise);

            var createdExercise = await this.exercisesService.CreateExercisee(exerciseToCreate);

            if (createdExercise == null)
            {
                return Conflict("The exercise you want to create already exists.");
            }

            var result = this.mapper.Map<ExerciseDetailsModel>(createdExercise);

            return Created("", result);
        }
    }
}
