using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime.Weather.Forecast.App.ModelsInterface
{
    public interface IAppLogger
    {
        void LogDebug(string message);
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);
    }
}
