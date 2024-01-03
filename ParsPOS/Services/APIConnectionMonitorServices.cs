using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public class APIConnectionMonitorServices : IHostedService
    {
        private readonly ILogger<APIConnectionMonitorServices> _logger;
        private readonly HttpClient _client;
        private CommonHttpServices _commonHttpServices;
        public APIConnectionMonitorServices(ILogger<APIConnectionMonitorServices> logger,HttpClient httpClient,CommonHttpServices commonHttpServices) 
        {
            _logger = logger;
            _client = httpClient;
            _commonHttpServices = commonHttpServices;
            httpClient.Timeout = TimeSpan.FromMinutes(3);

        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting API connection monitor");
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await CheckConnectionAsync();
                    await Task.Delay(TimeSpan.FromMinutes(1));
                }
            }, cancellationToken);
            return Task.CompletedTask;
        }

        private async Task CheckConnectionAsync()
        {
            try
            {
                var baseurl = _commonHttpServices.GetBaseUrl();
                string dataApiUrl = $"{baseurl}/api/DirectDb/HealthChk";
                var response = await _client.GetAsync(dataApiUrl, HttpCompletionOption.ResponseHeadersRead)
                              .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    // Update connection status in the app
                    App._Connected = true;
                    _logger.LogInformation("API connection is active");
                }
                else
                {
                    App._Connected = false;
                    _logger.LogWarning("API connection failed");
                }
            }
            catch (Exception ex)
            {
                App._Connected = false;
                _logger.LogError(ex, "Error checking API connection");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping API connection monitor");
            return Task.CompletedTask;
        }
    }
}
