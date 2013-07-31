using System.Net;
using System.Threading.Tasks;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using NavigatorApplication.Service.DTO;
    using NavigatorApplication.Service.Repository;
    using Raven.Client;
    using Raven.Client.Document;
    using System.Net.Http;
    using System.Web.Http;

    public class AtomEndpointController : RavenController
    {
        private readonly IFeedRepository feedRepository;

        private IDocumentSession _session;

        public AtomEndpointController(IFeedRepository feedRepository)
        {
            //this.feedRepository = urlRepository;

            //var _store = new DocumentStore()
            //{
             //   Url = "http://localhost:8081/"
            //};
            //_store.Initialize();
            //_store.JsonRequestFactory.DisableRequestCompression = true;
            //_session = _store.OpenSession();
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

        public async Task<HttpResponseMessage> Post(Model.Feed feed)
        {
            await Session.StoreAsync(feed);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }





        //public async Post(Model.Feed feed)
        //{
        //    if(feed != null)
        //    {
        //        Session.StoreAsync(feed);
        //        Session.SaveChangesAsync();
        //    }            
        //}


        public void Put(int id, string value)
        {
        }

        public void Delete(string id)
        {
        }

    }
}
