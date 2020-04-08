using System;

namespace AdidasWeather.SDK
{
    public class Weather
    {
        /// <summary>
        /// Координаты места.
        /// </summary>
        public GeographicalCoordinates Coordinates { get; set; }

        /// <summary>
        /// Идентификатор города.
        /// </summary>
        public int CityID { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Название страны
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Дата погоды.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Восход
        /// </summary>
        public string Sunrise { get; set; }

        /// <summary>
        /// Закат
        /// </summary>
        public string Sunset { get; set; }

        /// <summary>
        /// Текущая температура
        /// </summary>
        public Tempeature Temperature { get; set; }
        /// <summary>
        /// Ощущается как.
        /// </summary>
        public Tempeature FeelLikes { get; set; }

        /// <summary>
        /// Давление мм.рт.ст
        /// </summary>
        public double Pressure { get; set; }

        /// <summary>
        /// Влажность
        /// </summary>
        public double Humidity { get; set; }

        /// <summary>
        /// Скорость ветра
        /// </summary>
        public double WindSpeed { get; set; }

        /// <summary>
        /// Направление ветра
        /// </summary>
        public double WindDegree { get; set; }

        /// <summary>
        /// Описание погоды, ясно, легкий дождь и.т.д
        /// </summary>
        public string Description { get; set; }

    }
}
