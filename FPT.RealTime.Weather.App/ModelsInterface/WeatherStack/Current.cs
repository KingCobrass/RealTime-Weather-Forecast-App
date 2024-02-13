using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime.Weather.Forecast.App.ModelsInterface.WeatherStack
{
    public class Current
    {
        public string? observation_time { get; set; }
        public float temperature { get; set; }
        public int weather_code { get; set; }
        public List<string>? weather_icons { get; set; }
        public List<string>? weather_descriptions { get; set; }
        public float wind_speed { get; set; }
        public float wind_degree { get; set; }
        public string? wind_dir { get; set; }
        public float pressure { get; set; }
        public float precip { get; set; }
        public float humidity { get; set; }
        public float cloudcover { get; set; }
        public float feelslike { get; set; }
        public float uv_index { get; set; }
        public int visibility { get; set; }
    }
}
