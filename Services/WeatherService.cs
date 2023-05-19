using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ASPMVC.Models;

namespace ASPMVC.Services
{

    public class WeatherService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiKey = "b1ef608af8a1eaed8657f1a953a58148"; // replace with your API key



        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            using (var client = new HttpClient())
            {
                // Set the timeout here:
                client.Timeout = TimeSpan.FromSeconds(60);

                try
                {


                    var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric");
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherResponse>(responseBody);
                }


                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null;
                }
            }

        }
    }
}


