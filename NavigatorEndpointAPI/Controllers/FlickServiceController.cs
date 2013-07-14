using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Raven.Client;
using Raven.Client.Document;

namespace NavigatorEndpointAPI.Controllers
{
    public class FlickServiceController : Controller
    {
        private DocumentStore store;

        private IDocumentSession session { get; set; }
        //
        // GET: /FlickService/

        public FlickServiceController()
        {
            var store = new DocumentStore()
            {
                Url = "http://localhost:8080/"
            };
            store.Initialize();
            store.JsonRequestFactory.DisableRequestCompression = true;
            session = store.OpenSession();
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public string Index()
        {
            if(Request.RequestType == "GET")
            {
                var queryString = Request.QueryString;
                var hubMode = queryString.Get("mode");
                var hubTopic = queryString.Get("topic");
                var challenge = queryString.Get("challenge");
                var leaseSeconds = queryString.Get("lease_seconds");
                var verifyToken = queryString.Get("queryString");
                return challenge;
            } else if(Request.RequestType == "POST")
            {
                var stream = Request.InputStream;
                using(XmlTextReader xmlTextReader = new XmlTextReader(stream))
                {
                    var syncdicationFeed = SyndicationFeed.Load(xmlTextReader);
                    session.Store(syncdicationFeed);
                }              
            }
            return "ok";
        }

    }
}
