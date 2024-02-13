using RealTime.Weather.Forecast.App.ModelsInterface.WeatherStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime.Weather.Forecast.App.ModelsInterface
{
    public interface IWeatherStackService
    {
        Task<WeatherStackResponse> GetCurrentWeatherAsync(string? zipCode);
    }
}
