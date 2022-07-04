using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeatherWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<WeatherForecast> GetWeather()
        {
            List<WeatherForecast> weatherList = new List<WeatherForecast>();

            weatherList.Add(new WeatherForecast { CityName = "Uttarakhand", Temperature = Random.Shared.Next(-20, 55) });
            weatherList.Add(new WeatherForecast { CityName = "Up", Temperature = Random.Shared.Next(-20, 55) });
            weatherList.Add(new WeatherForecast { CityName = "Gurgaon", Temperature = Random.Shared.Next(-20, 55) });
            weatherList.Add(new WeatherForecast { CityName = "Delhi", Temperature = Random.Shared.Next(-20, 55) });
            weatherList.Add(new WeatherForecast { CityName = "Mp", Temperature = Random.Shared.Next(-20, 55) });

            return weatherList;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Hello()
        {
            return Ok("Welcome to weather forecast app.");
        }
    }
}