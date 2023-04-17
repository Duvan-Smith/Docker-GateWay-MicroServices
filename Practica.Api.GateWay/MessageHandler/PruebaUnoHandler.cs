using Practica.Api.GateWay.PruebaUnoRemote;
using System.Diagnostics;
using System.Text.Json;

namespace Practica.Api.GateWay.MessageHandler;

public class PruebaUnoHandler : DelegatingHandler
{
    private readonly ILogger<PruebaUnoHandler> _logger;

    public PruebaUnoHandler(ILogger<PruebaUnoHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var time = Stopwatch.StartNew();
        _logger.LogInformation("Inicia el tiempo");

        var response = await base.SendAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<IEnumerable<PruebaUnoDto>>(content, options);
        }

        _logger.LogInformation($"Tiempo {time.ElapsedMilliseconds}");
        return response;
    }
}
