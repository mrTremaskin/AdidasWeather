using AdidasWeather.SDK;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidasWeather.Controllers
{
    public class WeatherController: Controller
    {
        IWeather weatherAPI;

        public WeatherController(IWeather weather)
        {
            this.weatherAPI = weather;
        }

        public async Task<IActionResult> GetWeather(double Lon, double Lat)
        {
            var result = await weatherAPI.GetWeather(new GeographicalCoordinates(Lon, Lat));
            
            return Json(result);
        }
    }
}
