using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime.Weather.Forecast.App.ModelsInterface
{
    /// <summary>
    /// Weather stack settings
    /// </summary>
    public class WeatherStackSettings
    {
        /// <summary>
        /// API Key is required to comunicate with APIs
        /// </summary>
        [Required]
        public string? ApiKey { get; set; }
        /// <summary>
        /// Base Url
        /// </summary>
        [Required]
        public string? BaseUrl { get; set; }
    }
}
