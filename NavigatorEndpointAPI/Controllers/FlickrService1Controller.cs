using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Web.Http;

namespace NavigatorEndpointAPI.Controllers
{
    public class FlickrService1Controller : ApiController
    {        

        public FlickrService1Controller()
        {
            
        }

        public HttpResponseMessage Get()
        {
            var queryString = Request.RequestUri.ParseQueryString();
            var hubMode = queryString.Get("mode");
            var hubTopic = queryString.Get("topic");
            var challenge = queryString.Get("challenge");
            var leaseSeconds = queryString.Get("lease_seconds");
            var verifyToken = queryString.Get("queryString");
            var response = Request.CreateResponse();
            response.Content = new StringContent(challenge);
            return response;
        }

        public HttpResponseMessage Post([FromBody]string content)
        {
            var response = Request.CreateResponse();
            response.Content = new StringContent("ok");
            return response;
        }
    }
}
