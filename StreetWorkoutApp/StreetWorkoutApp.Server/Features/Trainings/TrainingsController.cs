using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

using StreetWorkoutApp.Server.Features.Trainings.Models;
using StreetWorkoutApp.Services.Trainings.Models;
using StreetWorkoutApp.Services.Trainings;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using StreetWorkoutApp.Server.Infrastructure;

namespace StreetWorkoutApp.Server.Features.Trainings
{
    [Authorize]
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

        public async Task<ActionResult<int>> CreateTrainingAsync([FromBody] CreateTrainingFormModel trainingModel)
        {
            var training = this.mapper.Map<CreateTrainingServiceModel>(trainingModel);

            var createdTrainingId = await this.trainingsService.CreateTrainingAsync(training, this.User.GetId());

            if (createdTrainingId == -1)
            {
                return BadRequest();
            }

            return Created("", createdTrainingId);
        }

        [HttpPut("edit")]
        [SwaggerOperation(
            Summary = "Create exercise",
            Description = "Creates a new exercise",
            OperationId = "CreateTraining")]

        public async Task<ActionResult<int>> EditTrainingAsync([FromBody] CreateTrainingFormModel trainingModel)
        {
            var training = this.mapper.Map<CreateTrainingServiceModel>(trainingModel);

            var createdTrainingId = await this.trainingsService.CreateTrainingAsync(training, this.User.GetId());

            if (createdTrainingId == -1)
            {
                return BadRequest();
            }

            return Created("", createdTrainingId);
        }

        [HttpGet("details/{trainingId}")]
        [SwaggerOperation(
            Summary = "Gets the details for current training",
            Description = "Gets the details for current traininge",
            OperationId = "GetTrainingDetails")]

        public ActionResult<TrainingDetailsModel> GetTrainingDetails(int trainingId)
        {
            var trainingDetails = this.trainingsService.GetTrainingDetails(trainingId);

            if (trainingDetails == null)
            {
                return NotFound("Such training does not exist.");
            }

            var result = this.mapper.Map<TrainingDetailsModel>(trainingDetails);

            return Ok(result);

        }

        [HttpPost("filter/{currentPage}/{resultsPerPage}")]
        [SwaggerOperation(
            Summary = "Gets given count of filtered trainings for the given page",
            Description = "Gets given count of filtered trainings for the given page",
            OperationId = "GetFilteredTrainings")]

        public ActionResult<FilteredTrainingsResponseModel> GetFilteredTrainings(
            int currentPage,
            int resultsPerPage,
            TrainingFiltersModel filters)
        {
            var serviceFilters = this.mapper.Map<TrainingFiltersServiceModel>(filters);

            var trainings = this.trainingsService.GetFilteredTrainings(currentPage, resultsPerPage, serviceFilters);

            var result = this.mapper.Map<FilteredTrainingsResponseModel>(trainings);

            return Ok(result);
        }

        [HttpDelete("delete/{trainingId}")]
        [SwaggerOperation(
            Summary = "Deletes the training with the given Id",
            Description = "GDeletes the training with the given Id",
            OperationId = "DeleteTraining")]

        public async Task<ActionResult<TrainingDetailsModel>> DeleteTrainingAsync(int trainingId)
        {
            var trainingDetails = await this.trainingsService.DeleteTrainingAsync(trainingId, this.User.GetId());

            if (trainingDetails)
            {
                return NotFound("Such training does not exist.");
            }

            var result = this.mapper.Map<TrainingDetailsModel>(trainingDetails);

            return Ok(result);

        }
    }
}
