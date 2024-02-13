using RealTime.Weather.Forecast.App.ModelsInterface;
using RealTime.Weather.Forecast.App.ModelsInterface.WeatherStack;
using RealTime.Weather.Forecast.App.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RealTime.Weather.Forecast.App.Services
{
    /// <summary>
    /// Will be responsible to communicate with Weather Stack APIs
    /// </summary>
    public class WeatherStackService : IWeatherStackService
    {
        private readonly HttpClient _httpClient;
        private readonly WeatherStackSettings? _watherStackSettings;
        private readonly IAppLogger _logger;

        public WeatherStackService(HttpClient httpClient,
           IOptions<WeatherStackSettings> settings,
           IAppLogger logger)
        {
            this._httpClient = httpClient;
            this._watherStackSettings = settings.Value;
            this._logger = logger;

            //Configure Http client based on BaseUrl
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this._httpClient.BaseAddress = new Uri(_watherStackSettings.BaseUrl);
        }
        /// <summary>
        /// Send request to WeatherStack to get current weather based on provided Zip code
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public async Task<WeatherStackResponse> GetCurrentWeatherAsync(string? zipCode)
        {
            try
            {
                this._logger.LogInfo($">> [WeatherStackService][GetCurrentWeatherAsync][Sending request to Weather stack to get current weather by Zip Code: {zipCode}]");

                //Make API path
                string apiPath = $"{AppConstants.CURRENT_WEATHER_API_PATH}?{AppConstants.ACCESS_KEY}={this._watherStackSettings?.ApiKey}&" +
                    $"{AppConstants.QUERY}={zipCode}";

                var response = await this._httpClient.GetAsync(apiPath);
                this._logger.LogInfo($">> [WeatherStackService][GetCurrentWeatherAsync][Received current weather: Response code:{response.StatusCode.ToString()}]");

                return await response.Content.ReadAsAsync<WeatherStackResponse>();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
