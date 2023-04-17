using Microsoft.AspNetCore.Mvc;

namespace Practica.Api.PruebaUno.Controllers
{
    [ApiController]
    [Route("apiPruebaUno/[controller]")]
    public class PruebaUnoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PruebaUnoController> _logger;

        public PruebaUnoController(ILogger<PruebaUnoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<PruebaUnoDto> Get()
        {
            return Enumerable.Range(1, 2).Select(index => new PruebaUnoDto
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Name = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}