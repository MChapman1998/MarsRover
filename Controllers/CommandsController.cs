using MarsRover.Interfaces;
using MarsRover.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers
{
    [ApiController]
    [Route("moveRover")]
    public class CommandsController : ControllerBase
    {
        private readonly IValidationService _validationService;
        private readonly IMovementService _movementService;

        public CommandsController(IValidationService validationService, IMovementService movementService)
        {
            _validationService = validationService;
            _movementService = movementService;
        }

        [HttpPost]
        public ActionResult<string> Post(Commands commands)
        {
            if (!_validationService.ValidateInput(commands))
            {
                return new BadRequestObjectResult("Incorrect command list passed. Please try again.");
            }

            string endingPosition = _movementService.HandleMovement(commands);
            return new OkObjectResult(endingPosition);
        }
    }
}