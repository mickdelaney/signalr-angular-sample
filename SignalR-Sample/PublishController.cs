using System.Web.Http;
using Microsoft.AspNet.SignalR;

namespace SignalR_Sample
{
    public class PublishController : ApiController
    {
        [HttpGet, Route("message")]
        public IHttpActionResult Get()
        {
            var model = new PublishGetModel();
            return Ok(model);
        }

        [HttpPost, Route("message")]
        public void Post(PublishPostModel model)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<BusHub>();
            hub.Clients.All.publish("messageSent", model.Message);
        }
    }
}