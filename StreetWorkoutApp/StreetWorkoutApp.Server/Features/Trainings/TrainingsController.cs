using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

using StreetWorkoutApp.Server.Features.Trainings.Models;
using StreetWorkoutApp.Services.Trainings.Models;
using StreetWorkoutApp.Services.Trainings;
using System;

namespace StreetWorkoutApp.Server.Features.Trainings
{
    public class TrainingsController : ApiController
    {
        private readonly IMapper mapper;
        private readonly ITrainingsService trainingsService;

        public TrainingsController(IMapper mapper, ITrainingsService trainingsService)
        {
            this.mapper = mapper;
            this.trainingsService = trainingsService;
        }

        [HttpPost("add")]
        [SwaggerOperation(
            Summary = "Create exercise",
            Description = "Creates a new exercise",
            OperationId = "CreateTraining")]

        public async Task<ActionResult<int>> CreateTraining([FromBody] CreateTrainingFormModel trainingModel)
        {
            var training = this.mapper.Map<CreateTrainingServiceModel>(trainingModel);

            var createdTrainingId = await this.trainingsService.CreateTraining(training);

            if (createdTrainingId == 0)
            {
                return Conflict("The training you want to create already exists.");
            }

            return Created("", createdTrainingId);
        }

        [HttpGet("details/{trainingId}")]
        [SwaggerOperation(
            Summary = "Gets the details for current training",
            Description = "Gets the details for current traininge",
            OperationId = "GetTrainingDetails")]

        public async Task<ActionResult<TrainingDetailsModel>> GetTrainingDetails(int trainingId)
        {
            var trainingDetails = this.trainingsService.GetTrainingDetails(trainingId);

            if (trainingDetails == null)
            {
                return NotFound("Such training does not exist.");
            }

            var result = this.mapper.Map<TrainingDetailsModel>(trainingDetails);

            return Ok(result);
        }

        [HttpPost("filter")]
        [SwaggerOperation(
            Summary = "Gets given count of filtered trainings for the given page",
            Description = "Gets given count of filtered trainings for the given page",
            OperationId = "GetFilteredTrainings")]

        public async Task<ActionResult<TrainingDetailsModel>> GetFilteredTrainings()
        {
            throw new NotImplementedException();
        }
    }
}
