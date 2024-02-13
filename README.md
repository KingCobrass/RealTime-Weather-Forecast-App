# RealTime-Weather-Forecast-App
Real-Time Weather Updates Console App is a user-friendly tool designed to deliver current weather information instantly. With a simple interface, users can access accurate weather forecasts by entering either a Zip code or a city name. I used Weatherstack APIs to get real time weather updates.

**Tools & Technology Used**
- .Net 8
- Weatherstack API integration
- Service based HttpClient to communicate 3rd party APIs
- Configurable 3rd Pary APIs credentials
- Serilog
  - Configurable file system to manage log data  

**Key Features:**

- Instant Weather Updates: Users can receive real-time weather updates by inputting either a Zip code or a city name. The application fetches the latest weather data from reliable sources to ensure accuracy.
- Zip Code and City Name Support: Whether users have a Zip code handy or prefer to search by city name, our app accommodates both methods, offering flexibility and convenience.

**How to run**
- Check out main branch and open it Visual studio 2022
- Make sure you have installed .net 8
- Put your WeatherStack API credentials into the appsettings.json file. You may manage two separate settings files for development and production environments.
- Build application and run
