using RealTime.Weather.Forecast.App.ModelsInterface;
using RealTime.Weather.Forecast.App.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Configuration;
using System;
using System.Text;
using RealTime.Weather.Forecast.App.Utilities;
using RealTime.Weather.Forecast.App.ModelsInterface.WeatherStack;
using RealTime.Weather.Forecast.App.Extensions;


try
{
    // Build configuration
    var configuration = InitializedConfiguration();
    Log.Logger = InitLogConfiguration(configuration);
    AppLogger log = new(Log.Logger);
    WelcomeApplication(log);

    //Install services
    ServiceCollection services = InstallServices(configuration, log);
    var provider = services.BuildServiceProvider();
    //Get Weather stack services to do APIs call
    var weatherService = provider.GetService<IWeatherStackService>();

    while (true)
    {
        //Prompt user for Zip code
        Console.WriteLine(AppConstants.ZIP_CODE_INPUT_INSTRUCTION);
        string? zipCode = Console.ReadLine();
        var response = weatherService is null ? null : await weatherService.GetCurrentWeatherAsync(zipCode);


        if (response is not null) PrepareQuestionAnswer(response);
        else Console.WriteLine(AppConstants.GENERRIC_ERROR_MESSAGE);


        Console.WriteLine(AppConstants.MORE_WEATHER_UPDATE);
        var interested = Console.ReadLine();
        if (string.IsNullOrEmpty(interested)
           || interested.ToLower().Equals("n")) break;

    }
    Console.WriteLine(AppConstants.GOODBAY_MESSAGE);
}
catch (Exception ex)
{
    Console.WriteLine(AppConstants.GENERRIC_ERROR_MESSAGE);
    Log.Logger.Error($">> [RealTime.Weather.Forecast.App][Error:: {ex.Message}][StackTrace:: {ex.StackTrace}]");
}

void PrepareQuestionAnswer(WeatherStackResponse response)
{

    try
    {
        if (response.error == null)
        {
            bool isRaining = false;
            bool isWindSpeedOverLimit = false;
            bool isUVIndexLimitOver = false;
            if (response.current is not null)
            {
                (isRaining, isWindSpeedOverLimit, isUVIndexLimitOver) = CheckQuestionAnswer(response.current);


                //Raining logic check
                Console.WriteLine(AppConstants.SHOULD_I_GO_OUTSIDE);
                if (isRaining) Console.WriteLine(AppConstants.NO);
                else Console.WriteLine(AppConstants.YES);

                //UV Index Checking
                Console.WriteLine(AppConstants.SHOULD_I_WEAR_SUNSCREEN);
                if (isUVIndexLimitOver) Console.WriteLine(AppConstants.YES);
                else Console.WriteLine(AppConstants.NO);

                //Wind Speed check
                Console.WriteLine(AppConstants.CAN_I_FLY_MY_KITE);
                if (!isRaining && isWindSpeedOverLimit) Console.WriteLine(AppConstants.YES);
                else Console.WriteLine(AppConstants.NO);

            }
            else
            {
                Console.WriteLine(AppConstants.GENERRIC_ERROR_MESSAGE);
                Log.Logger.Warning(AppConstants.CURRENT_WEATHER_IS_EMPTY);
            }

        }
        else
        {
            if (response.error.code.Equals(615))
                Console.WriteLine(AppConstants.FAILED_RESPONSE_FOR_INVALID_ZIP_CODE_DISPLAY);
            else Console.WriteLine(string.Format(AppConstants.FAILED_RESPONSE_DISPLAY, response.error.info));


            Log.Logger.Warning(string.Format(AppConstants.FAILED_MESSAGE_CONSTRUCTION, response.error.code, response.error.info, response.error.type));
        }
    }
    catch (Exception)
    {

        throw;
    }
}

(bool isRaining, bool isWindSpeedOverLimit, bool isUVIndexLimitOver) CheckQuestionAnswer(Current current)
{
    bool isRaining = false;
    bool isWindSpeedOverLimit = false;
    bool isUVIndexLimitOver = false;
    if (current.weather_descriptions?.Count > 0)
    {
        if (current.weather_descriptions.Contains(AppConstants.RAINING)
            || current.weather_descriptions.Contains(AppConstants.RAIN)) isRaining = true;
    }

    if (current.wind_speed > AppConstants.WIND_SPEED_THRESHOLD) isWindSpeedOverLimit = true;
    if (current.uv_index > AppConstants.UV_INDEX_THRESHOLD) isUVIndexLimitOver = true;

    return (isRaining, isWindSpeedOverLimit, isUVIndexLimitOver);

}

#region Install Service, Configuration, Welcome message


static ServiceCollection InstallServices(IConfiguration configuration, AppLogger log)
{
    ServiceCollection services = new();

    services.AddConfigurationServices(configuration);
    services.AddCoreServices();

    return services;
}


static IConfiguration InitializedConfiguration()
{

    return new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
         .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "prod"}.json", true)
         .Build();

}
static ILogger InitLogConfiguration(IConfiguration configuration)
{
    return new LoggerConfiguration()
                         .ReadFrom.Configuration(configuration)
                         .Enrich.FromLogContext()
                         .CreateLogger();
}

/// <summary>
/// Get weather stack response properly
/// </summary>
static void WelcomeApplication(AppLogger logger)
{
    StringBuilder sb = new();
    sb.AppendLine();
    sb.AppendLine("*******************************************************");
    sb.AppendLine("**          Real Time Weather Forecast App           **");
    sb.AppendLine("**                  [Version 1.0.0]                  **");
    sb.AppendLine("*******************************************************");

    Console.WriteLine(sb.ToString());
    logger.LogInfo(sb.ToString());
}

#endregion
