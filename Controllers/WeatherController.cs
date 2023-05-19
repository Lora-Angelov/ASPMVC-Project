using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPMVC.Models; 
using ASPMVC.Services; 

namespace ASPMVC.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return View(new WeatherResponse());
            }

            var model = await _weatherService.GetWeatherAsync(city);
            return View(model);
        }
    }
}
