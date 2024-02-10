using ParsVanSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Services
{
    public class CommonHttpServices
    {
        private HttpClient client;

        public CommonHttpServices()
        {
//#if DEBUG
            HttpClientHandlerService handler = new HttpClientHandlerService();
            client = new HttpClient(handler.GetPlatformMessageHandler());
            
//#else
//        client = new HttpClient();
//#endif
        }

        public HttpClient GetHttpClient()
        {
            return client;
        }

        public string GetBaseUrl()
        {
            NetworkIP network = App.Database.GetActiveIP().Result;
            return DeviceInfo.Platform == DevicePlatform.Android ? $"{network.Protocol}://{network.IPAddress}/Api": $"{network.Protocol}://{network.IPAddress}/Api";
        }
    }
}
