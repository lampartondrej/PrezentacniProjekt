using PrezentacniProjekt.Shared.Model.DTOs.Shared;
using PrezentacniProjekt.Shared.Model.DTOs.Weatherstack.Current.Request;
using PrezentacniProjekt.Shared.Model.DTOs.Weatherstack.Current.Response;
using PrezentacniProjekt.Shared.Model.DTOs.Weatherstack.Forecast.Request;
using PrezentacniProjekt.Shared.Model.DTOs.Weatherstack.Forecast.Response;

namespace PrezentacniProjekt.Services.Interfaces
{
    /// <summary>
    /// Service interface for retrieving weather information from Weatherstack API.
    /// </summary>
    public interface IWeatherService
    {
        Task<(CurrentWeatherResponse?, DetailedErrorMessage?)> GetCurrentWeather(GetCurrentWeatherRequest currentWeatherRequest);
        Task<(ForecastWeatherResponse?, DetailedErrorMessage?)> GetForecastWeather(GetForecastWeatherRequest forecastWeatherRequest);
    }
}
