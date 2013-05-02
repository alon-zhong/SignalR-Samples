using System;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

namespace WebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            HubConfiguration hubConfiguration = new HubConfiguration()
            {
                EnableCrossDomain = true,
                EnableDetailedErrors = true,
                EnableJavaScriptProxies = true,
            };
            RouteTable.Routes.MapHubs(hubConfiguration);
        }
    }
}