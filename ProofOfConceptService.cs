using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

class ProofOfConceptService : BackgroundService 
{ 
    private HttpClient _http;
    private ILogger<ProofOfConceptService> _logger;

    public ProofOfConceptService(HttpClient http, ILogger<ProofOfConceptService> logger)
    {
        _http = http;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("-- burp --");
            _logger.LogInformation("GET");
            await _http.GetAsync("https://google.com");
            _logger.LogInformation("DONE");

            await Task.Delay(TimeSpan.FromSeconds(3));
        }
    }
}

