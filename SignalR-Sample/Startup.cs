using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR_Sample.Startup))]
namespace SignalR_Sample
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}