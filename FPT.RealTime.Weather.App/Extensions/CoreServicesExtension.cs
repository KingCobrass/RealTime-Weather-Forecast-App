using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealTime.Weather.Forecast.App.ModelsInterface;
using RealTime.Weather.Forecast.App.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime.Weather.Forecast.App.Extensions
{
    /// <summary>
    /// To managable service activation
    /// </summary>
    public static class CoreServicesExtension
    {
        /// <summary>
        /// Add configuration services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddConfigurationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IAppLogger>(new AppLogger(Log.Logger));
            services.Configure<WeatherStackSettings>(config.GetSection(nameof(WeatherStackSettings)));
        }
        /// <summary>
        /// Add core services
        /// </summary>
        /// <param name="services"></param>
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddHttpClient<IWeatherStackService, WeatherStackService>();
        }
    }
}
