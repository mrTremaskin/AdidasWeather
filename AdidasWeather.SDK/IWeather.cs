using System.Threading.Tasks;

namespace AdidasWeather.SDK
{
    public interface IWeather
    {
        Task<Weather> GetWeather(GeographicalCoordinates Coord);
    }
}
