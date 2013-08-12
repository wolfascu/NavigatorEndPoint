using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using log4net;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    public class FlickrSubscribeController : ApiController
    {
        //
        // GET: /FlickrSubscribe/
        private static readonly ILog logger = LogManager.GetLogger(typeof (FlickrSubscribeController));
        
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
            logger.InfoFormat("challenge => {0}", challenge);
            return response;
        }

    }
}
