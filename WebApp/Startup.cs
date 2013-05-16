using Microsoft.AspNet.SignalR;
using Owin;

namespace WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HubConfiguration hubConfiguration = new HubConfiguration()
            {
                EnableCrossDomain = true,
                EnableDetailedErrors = true,
                EnableJavaScriptProxies = true,
            };
            app.MapHubs(hubConfiguration);
        }
    }
}