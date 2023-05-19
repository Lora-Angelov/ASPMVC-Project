/*using System.Threading.Tasks;
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
}*/


/* ///NEW ADDED
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ASPMVC.Models;
using ASPMVC.Services;

namespace ASPMVC.Controllers
{
    public class WeatherController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        //private const string apiKey = "13ced7965380427c7ba4f8a0c5a00847";  // replace with your own API key

        public async Task<Root> GetWeatherAsync(string city)
        {
            var apiKey = "13ced7965380427c7ba4f8a0c5a00847";
            var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/forecast?id=524901&appid={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Root>(stringResponse);

                return model;
            }
            else
            {
                throw new HttpRequestException("Failed to get weather data");
            }
        }


        public async Task<IActionResult> Index(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {
                var model = await _weatherService.GetWeatherAsync(city);
                return View(model);
            }

            return View();
        }
    }
} // UP TO HERE
*/




/*public async Task<IActionResult> Index(string city)
{
    WeatherResponse model = null;

    if (!string.IsNullOrEmpty(city))
    {
        var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/forecast?id=524901&appid={apiKey}");

        if (response.IsSuccessStatusCode)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<Root>(stringResponse);
        }
    }

    return View(model);
}
}
}*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using ASPMVC.Models;

namespace ASPMVC.Controllers
{
    /*public class WeatherController : Controller
    {
        private readonly HttpClient _client;

        public WeatherController(HttpClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetWeather(string city)
        {
            var model = await GetWeatherAsync(city);
            return View("Index", model);
        }

        private async Task<Root> GetWeatherAsync(string city)
        {
            var apiKey = "13ced7965380427c7ba4f8a0c5a00847";
            var response = await _client.GetAsync($"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Root>(stringResponse);

                return model;
            }
            else
            {
                throw new HttpRequestException("Failed to get weather data");
            }
        }
    }*/


    public class WeatherController : Controller
    {
        private readonly HttpClient _client;

        public WeatherController(HttpClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return View();  // returns an empty view when no city is provided
            }

            var model = await GetWeatherAsync(city);
            return View(model);
        }

        private async Task<Root> GetWeatherAsync(string city)
        {
            var apiKey = "13ced7965380427c7ba4f8a0c5a00847";
            var response = await _client.GetAsync($"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Root>(stringResponse);

                return model;
            }
            else
            {
                throw new HttpRequestException("Failed to get weather data");
            }
        }
    }

}


