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


        //authorize for either admin or viewer only
        //[Authorize(Roles ="Admin,Viewer")]

        //multiple role auth.
        // [Authorize(Roles = "Admin")]
        //[Authorize(Roles = "Viewer")]

        //policy : collection of claims(user's personal info )
        [HttpGet]
        [Authorize(Policy="AgeOver18")]
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
        [Authorize(Policy = "RequiredMultipleRole")]
       // [AllowAnonymous]
        public ActionResult Hello()
        {
            return Ok("Welcome to weather forecast app.");
        }
    }
}