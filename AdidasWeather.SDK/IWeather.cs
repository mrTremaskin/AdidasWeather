using System.Threading.Tasks;

namespace AdidasWeather.SDK
{
    public interface IWeather
    {
        Task<Weather> GetWeather(int CityID);
        Task<Weather> GetWeather(GeographicalCoordinates Coord);
    }
}
