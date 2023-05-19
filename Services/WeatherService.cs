using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ASPMVC.Models;

namespace ASPMVC.Services
{

    public class WeatherService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiKey = "13ced7965380427c7ba4f8a0c5a00847"; // replace with your API key



        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            using (var client = new HttpClient())
            {
                // Set the timeout here:
                client.Timeout = TimeSpan.FromSeconds(60);

                try
                {


                    var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/forecast?id=524901&appid={apiKey}");
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


