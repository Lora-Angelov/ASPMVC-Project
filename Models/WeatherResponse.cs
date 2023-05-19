using Newtonsoft.Json;

namespace ASPMVC.Models
{

    public class WeatherResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public float Temp { get; set; }

        [JsonProperty("humidity")]
        public float Humidity { get; set; }
    }


}
