using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime.Weather.Forecast.App.Utilities
{
    public class AppConstants
    {
        #region General Messaging
        public const string ZIP_CODE_INPUT_INSTRUCTION = ">>  Please enter your Zip Code to get the latest weather update";
        public const string LOADING_WEATHER_UPDATE_INSTRUCTION = ">> Please wait a while, weather update is loading...";
        public const string MORE_WEATHER_UPDATE= ">> Would you like to check further weather updates? Please respond with 'y' for yes or 'n' for no.";

        //

        #endregion

        #region Question & Answer
        public const string SHOULD_I_GO_OUTSIDE = ">> Should I go outside?";
        public const string SHOULD_I_WEAR_SUNSCREEN = ">> Should I wear sunscreen?";
        public const string CAN_I_FLY_MY_KITE = ">> Can I fly my kite?";


        public const string YES = ">>  Yes";
        public const string YES_CAPITAL = ">>  YES";
        public const string NO_CAPITAL = ">>  NO";
        public const string NO = ">>  No";



        // Threshold value
        public const int WIND_SPEED_THRESHOLD = 15;
        public const int UV_INDEX_THRESHOLD = 3;
        public const string RAINING = "Raining";
        public const string RAIN = "Rain";


        #endregion

        #region Weather stack constant
        //Path
        public const string CURRENT_WEATHER_API_PATH = "current";

        //Parameters
        public const string ACCESS_KEY = "access_key";
        public const string QUERY = "query";

        //response message
        public const string FAILED_MESSAGE_CONSTRUCTION = ">> Weather Stack Response Code:{0}, Info:{1}, Type:{2}.";
        public const string FAILED_RESPONSE_FOR_INVALID_ZIP_CODE_DISPLAY = ">> Please make sure you have provided a valid Zip code";
        public const string FAILED_RESPONSE_DISPLAY = ">> Unexpected response:{0}. Please review the log file for additional information, or reach out to your administrator for assistance.";
        public const string GENERRIC_ERROR_MESSAGE = ">> Something went wrong!. Please review the log file for additional information, or reach out to your administrator for assistance.";
        public const string CURRENT_WEATHER_IS_EMPTY = ">> The current weather update is either missing or unavailable.!";
        public const string PRESS_ANY_KEY= ">> Press any key to close.";
        public const string GOODBAY_MESSAGE = ">> See you again!";
        #endregion
    }
}
