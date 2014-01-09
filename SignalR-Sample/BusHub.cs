using Microsoft.AspNet.SignalR;

namespace SignalR_Sample
{
    public class BusHub : Hub
    {
        public void Publish(string key, object data)
        {
            Clients.All.publish(key, data);
        }
    }
}