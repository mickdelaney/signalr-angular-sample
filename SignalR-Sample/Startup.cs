using System.Web.Http;
using Microsoft.Owin;
using Owin;
using RazorEngine.Templating;
using WebApiContrib.Formatting.Razor;

[assembly: OwinStartup(typeof(SignalR_Sample.Startup))]
namespace SignalR_Sample
{

    public class Startup
    {
        MessageConsumer _consumer;

        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            var viewParser = new RazorViewParser(baseTemplateType: typeof(HtmlTemplateBase<>));
            config.Formatters.Add(new RazorViewFormatter(viewParser: viewParser));
            app.UseWebApi(config);

            app.MapSignalR();

            _consumer = new MessageConsumer();
            _consumer.Start();
        }
    }
}