using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost]
        public string Get()
        {
            return string.Empty;
        }
    }
}
