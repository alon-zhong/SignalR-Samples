using Microsoft.AspNet.SignalR;
using Owin;

namespace ConsoleApp
{
    class Startup
    {
        // This method name is important
        public void Configuration(IAppBuilder app)
        {
            var config = new HubConfiguration
            {
                EnableCrossDomain = true
            };

            app.MapHubs(config);
        }
    }
}
