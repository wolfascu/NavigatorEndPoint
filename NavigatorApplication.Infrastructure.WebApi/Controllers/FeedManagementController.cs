namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Threading.Tasks;
    using NavigatorApplication.Service.DTO.Flickr;
    using NavigatorApplication.Service.Repository;

    public class FeedManagementController : RavenController
    {
        private readonly IFeedRepository feedRepository;
        
        public FeedManagementController()
        {
            this.feedRepository = feedRepository;
        }

        public async Task<FlickrFeed> Get(string id)
        {
            var test = id;
            return await Session.LoadAsync<FlickrFeed>(id);
        }

    }
}
