using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime.Weather.Forecast.App.ModelsInterface.WeatherStack
{
    public class Request
    {
        public string? type { get; set; }
        public string? query { get; set; }
        public string? language { get; set; }
        public string? unit { get; set; }
    }
}
