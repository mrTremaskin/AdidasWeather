using AdidasWeather.SDK;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace OpenWeatherAPI
{
    public class OpenWeatherAPI: IWeather
    {
        readonly string apiKey;
        public OpenWeatherAPI(string ApiKey)
        {
            this.apiKey = ApiKey;
        }

        public async Task<Weather> GetWeather(GeographicalCoordinates Coord)
        {
            string result = await getData($"https://api.openweathermap.org/data/2.5/weather?lat={Coord.Lat}&lon={Coord.Lon}&appid={this.apiKey}");
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenWeatherAPIData>(result);
                
            return obj.ToWeather();
        }

        private async Task<string> getData(string request)
        {
            string result;

            using (var httpClient = new HttpClient())
            {
                result = await (await httpClient.GetAsync(request)).Content.ReadAsStringAsync();
            }

            return result;
        }
    }

    public sealed class OpenWeatherAPIData 
    {
        public GeographicalCoordinates coord;
        public IEnumerable<WeatherDescription> weather;
        public WeatherMain main;
        public double visibility;
        public Wind wind;
        public int dt;
        public OpenWeatherAPISys sys;
        public string timesonze;
        public string name;
        public int cod;

        public Weather ToWeather() {

            if(cod == 200)
            {
                var mainWeather = this.weather.FirstOrDefault();

                return  new Weather()
                {
                    Coordinates = coord,
                    CityID = sys.id,
                    CityName = name,
                    Country = sys.country,
                    Date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(dt).ToLocalTime().ToString(),
                    Description = $"{mainWeather.main}, {mainWeather.description}",
                    FeelLikes = new Tempeature(main.feels_like, TemperatureType.Kelvin),
                    Temperature = new Tempeature(main.temp, TemperatureType.Kelvin),
                    Humidity = main.humidity,

                    // Конвертируем в мм.рт.ст.
                    Pressure = main.pressure / 1.333,
                    WindSpeed = wind.speed,
                    WindDegree = wind.deg,
                    Sunrise = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(sys.sunrise).ToLocalTime().ToString(),
                    Sunset = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(sys.sunset).ToLocalTime().ToString(),
                };
            }
            
            return null;
        }
    }

    public class OpenWeatherAPISys
    {
        public int type;
        public int id;
        public string country;
        public int sunrise;
        public int sunset;
    }

    public class WeatherDescription
    {
        public string main;
        public string description;
    }

    public class WeatherMain
    {
        public double temp;
        public double feels_like;
        public double pressure;
        public double humidity;
    }

    public class Wind
    {
        public double speed;
        public double deg;
    }
}
