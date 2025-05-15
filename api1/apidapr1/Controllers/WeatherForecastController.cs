using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace apidapr1.Controllers
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

        [HttpGet(template:"get-weather", Name = "GetWeatherForecast")]
        public async Task<string> Get([FromServices] DaprClient daprClient)
        {
            //try
            //{
            //    var c = new HttpClient();
            //    var xx = await c.GetAsync("http://zipkin:9411/api/v2/spans");
            //    var ff = xx.StatusCode;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Error in GetWeatherForecast");
            //}   
            var hn = Environment.MachineName;   
            var client = DaprClient.CreateInvokeHttpClient(appId: "apidapr2");
            //var client = daprClient.CreateInvokableHttpClient();   
            var response = await client.GetAsync("/weatherforecast/get-hostname");
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return result??"";
            }
            else
            {
                return $"status code {response.StatusCode}: {result}";
            }   
        }

        [HttpGet(template: "get-hostname", Name = "GetHostName")]
        public string GetHostName()
        {
            return Environment.MachineName;
        }
    }
}
