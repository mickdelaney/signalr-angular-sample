using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiContrib.Formatting.Html;

namespace SignalR_Sample
{
    [View("PublishGetView")]
    public class PublishGetModel
    {
    }

    public class PublishPostModel
    {
        public string Message { get; set; }
    }
}