using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NavigatorApplication.Infrastructure.WebApi.Model;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    public class FlickrServiceController : ApiController
    {
        public HttpResponseMessage Post(Feed feed)
        {
            var response = Request.CreateResponse();
            response.Content = new StringContent("ok");
            return response;
        }


    }
}
