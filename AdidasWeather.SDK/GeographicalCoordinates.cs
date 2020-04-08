namespace AdidasWeather.SDK
{
    public class GeographicalCoordinates
    {
        public double Lon { get; }
        public double Lat { get; }

        public GeographicalCoordinates(double Lon, double Lat)
        {
            this.Lon = Lon;
            this.Lat = Lat;
        }
    }
}
