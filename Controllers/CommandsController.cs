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

        public CommandsController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        [HttpPost]
        public ActionResult<string> Post(Commands commands)
        {
            if(!_validationService.ValidateInput(commands))
            {
                return new BadRequestObjectResult("Incorrect command list passed. Please try again.");
            }

            //continue
            return new OkObjectResult("Commands accepted");
        }
    }
}
