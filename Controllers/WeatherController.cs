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
            if (!string.IsNullOrEmpty(city))
            {
                var model = await GetWeatherAsync(city);

                if (model == null)
                {
                    ViewBag.ErrorMessage = "Invalid city name. Please try again.";
                    return View();
                }
                return View(model);
            }
            else
            {
                return View();
            }
        }


        private async Task<Root> GetWeatherAsync(string city)
        {
            var apiKey = "13ced7965380427c7ba4f8a0c5a00847";
            try
            {
                var response = await _client.GetAsync($"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}");

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<Root>(stringResponse);

                    return model;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }


    }
}


