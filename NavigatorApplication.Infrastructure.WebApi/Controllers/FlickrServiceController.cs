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

        public async Task<FlickrSaveFeed> Get(string id)
        {
            return await Session.LoadAsync<FlickrSaveFeed>(id);
        }

        public async Task<HttpResponseMessage> Post(FlickrSaveFeed flickrFeed)
        {
            await Session.StoreAsync(flickrFeed);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public async Task<HttpResponseMessage> Delete(FlickrDeleteFeed flickrFeed)
        {
            HttpResponseMessage response;
            FlickrFeed feedToDelete = await Session.LoadAsync<FlickrFeed>(flickrFeed.Id);
            if (feedToDelete != null)
            {
                Session.Delete<FlickrFeed>(feedToDelete);
                response = new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.Conflict);
            }
            return response;
        }
    }
}