using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public class CommonHttpServices
    {
        private HttpClient client;

        public CommonHttpServices()
        {
#if DEBUG
            HttpClientHandlerService handler = new HttpClientHandlerService();
            client = new HttpClient(handler.GetPlatformMessageHandler());
#else
        client = new HttpClient();
#endif
        }

        public HttpClient GetHttpClient()
        {
            return client;
        }

        public string GetBaseUrl()
        {
            return DeviceInfo.Platform == DevicePlatform.Android ? "https://10.10.2.35:7252" : "https://localhost:7252";
        }
        
        public async Task<bool> IsApiAvailable(CancellationToken cancellationToken = default)
        {
            try
            {
                var baseurl = GetBaseUrl();
                string apiUrl = $"{baseurl}/api/DirectDb/healthcheck";

                // Use a shorter timeout for the HTTP request (e.g., 3 seconds)
                using (var timeoutCancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
                using (var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCancellationTokenSource.Token))
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl, linkedCancellationTokenSource.Token);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception)
            {
                // Log or handle the exception as needed
                return false;
            }
        }
    }
}
