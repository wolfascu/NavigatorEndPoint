namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using NavigatorApplication.Service.DTO.Flickr;
    using NavigatorApplication.Service.Repository; 

    public class FlickrServiceController : RavenController
    {
        private readonly IFeedRepository feedRepository;

        //FlickrServiceController(IFeedRepository feedRepository)
        //{
        //    this.feedRepository = feedRepository;
        //}

        public Task<FlickrFeed> Get(string id)
        {
            return Session.LoadAsync<FlickrFeed>(id);
        }

        public async Task<HttpResponseMessage> Post(FlickrFeed flickerFeed)
        {
            await Session.StoreAsync(flickerFeed);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}