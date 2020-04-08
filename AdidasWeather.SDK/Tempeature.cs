namespace AdidasWeather.SDK
{
    public class Tempeature
    {
        private double rawTemperature;
        private TemperatureType rawType;

        public double Celsius
        {
            get
            {
                double value = rawTemperature;

                switch (rawType)
                {
                    case TemperatureType.Kelvin:
                        value = rawTemperature - 273.15;
                        break;

                    case TemperatureType.Fahrenheit:
                        value = (rawTemperature - 32) * 5 / 9;
                        break;
                    default:
                        break;
                }

                return value;
            }
        }

        public double Kelvin
        {
            get
            {
                double value = rawTemperature;

                switch (rawType)
                {
                    case TemperatureType.Celsius:
                        value = rawTemperature + 273.15;
                        break;

                    case TemperatureType.Fahrenheit:
                        value = (rawTemperature - 32) * 5 / 9 + 273.15;
                        break;
                    default:
                        break;
                }

                return value;
            }
        }

        public Tempeature(double Temperature, TemperatureType Type)
        {
            this.rawTemperature = Temperature;
            this.rawType = Type;
        }
    }
}
