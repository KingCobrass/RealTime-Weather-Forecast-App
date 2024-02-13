using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime.Weather.Forecast.App.ModelsInterface
{
    public class AppLogger: IAppLogger
    {
        private readonly ILogger _logger;
        public AppLogger(ILogger logger)
        {
            this._logger = logger;
        }

        public void LogDebug(string message) { this._logger.Debug(message); }
        public void LogInfo(string message) { this._logger.Information(message); }
        public void LogError(string message) { this._logger.Error(message); }
        public void LogWarning(string message) { this._logger.Warning(message); }
    }
}
