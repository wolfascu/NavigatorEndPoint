using NavigatorApplication.Infrastructure.WebApi.Extensions.Filter;

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

        public async Task<FlickrFeed> Get(string id)
        {
            var test = id;
            return await Session.LoadAsync<FlickrFeed>(id);
        }

        [TokenValidation]
        public async Task<HttpResponseMessage> Post(FlickrFeed flickrFeed)
        {
            await Session.StoreAsync(flickrFeed);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}