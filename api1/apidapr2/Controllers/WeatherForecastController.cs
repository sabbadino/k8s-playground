using Microsoft.AspNetCore.Mvc;

namespace apidapr2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(template: "get-weather", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var x = Environment.MachineName;    
            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet(template: "get-hostname", Name = "GetHostName")]
        public string GetHostName()
        {
            var x = Environment.MachineName;
            return Environment.MachineName;
        }
    }
}
