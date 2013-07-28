using System.Net.Http;
using System.ServiceModel.Syndication;
using Raven.Client;
using Raven.Client.Document;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using NavigatorApplication.Service.DTO;
    using NavigatorApplication.Service.Repository;

    public class AtomEndpointController : ApiController
    {
        //Create Atom Endpoint to Recieve Flickr Feeds
        //http://ben.onfabrik.com/posts/atompub-aspnet-web-api-part1
        
        private readonly IFeedRepository feedRepository;

        private IDocumentSession _session;

        public AtomEndpointController(IFeedRepository urlRepository)
        {
            this.feedRepository = urlRepository;

            var _store = new DocumentStore()
            {
                Url = "http://localhost:8080/"
            };
            _store.Initialize();
            _store.JsonRequestFactory.DisableRequestCompression = true;
            _session = _store.OpenSession();
        }

        public HttpResponseMessage Get(string mode, string topic, string challenge)
        {
            var response = Request.CreateResponse();
            response.Content = new StringContent(challenge);
            return response;
        }

        public Feed Get(string id)
        {
            return feedRepository.Get(id);
        }

        public void Post(Model.Feed feed)
        {
            if(feed != null)
            {
                _session.Store(feed);
                _session.SaveChanges();
            }            
        }

        public void Put(int id, string value)
        {
        }

        public void Delete(string id)
        {
        }

    }
}
