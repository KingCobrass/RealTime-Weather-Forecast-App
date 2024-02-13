using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime.Weather.Forecast.App.ModelsInterface.WeatherStack
{
    /// <summary>
    /// Get weather stack response properly
    /// </summary>
    public class WeatherStackResponse
    {
        public Request? request { get; set; }
        public Location? location { get; set; }
        public Current? current { get; set; }

        public bool success { get; set; }
        public Error? error { get; set; }
    }
}
