using System;
using Leatherback.Core.Attributes;
using Leatherback.Core.Entity;

namespace Turtle.Test
{
    [LeatherbackController("api/weather", SearchCriteria = typeof(WeatherForecastSearchCriteria))]
    public class WeatherForecast : ILeatherbackEntity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        public Guid Id { get; set; }
    }
}
