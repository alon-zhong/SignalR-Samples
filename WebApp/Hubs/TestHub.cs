using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace WebApp.Hubs
{
    public class TestHub : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        public void SendToCaller(string value)
        {
            Clients.Caller.received(value);
        }
    }
}
