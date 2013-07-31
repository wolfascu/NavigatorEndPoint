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

        public Task<FlickerFeed> Get(string id)
        {
            return Session.LoadAsync<FlickerFeed>(id);
        }

        public async Task<HttpResponseMessage> Post(FlickerFeed flickerFeed)
        {
            await Session.StoreAsync(flickerFeed);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}