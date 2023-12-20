using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return DeviceInfo.Platform == DevicePlatform.Android ? "https://10.10.1.248:7252" : "https://localhost:7252";
        }
    }
}
