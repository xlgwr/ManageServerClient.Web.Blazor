using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ManageServerClient.Web.Blazor.Data
{
    public class WeatherForecastService
    {
        private readonly ILogger<WeatherForecastService> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public WeatherForecastService(ILogger<WeatherForecastService> logger)
        {
            _logger = logger;
        }
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            _logger.LogInformation(startDate.ToString());
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
