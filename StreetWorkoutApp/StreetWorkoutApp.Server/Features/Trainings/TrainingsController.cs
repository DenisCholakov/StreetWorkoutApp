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

        [HttpPost("details/{trainingId}")]
        [SwaggerOperation(
            Summary = "Gets the details for current training",
            Description = "Gets the details for current traininge",
            OperationId = "GetTrainingDetails")]

        public async Task<ActionResult<TrainingDetailsModel>> GetTrainingDetails(int trainingId)
        {
            var trainingDetails = this.trainingsService.GetTrainingDetails(trainingId);

            throw new NotImplementedException();
        }
    }
}
