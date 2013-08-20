namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Collections.Generic;

    using NavigatorApplication.Service.Model;
    using NavigatorApplication.Service.Repository;
  
    public class FeedManagementController : RavenController
    {
        private readonly IFeedRepository feedRepository;
        
        public FeedManagementController()
        {
            this.feedRepository = feedRepository;
        }

        //public async Task<FlickrFeed> Get(string id)
        //{
        //    var test = id;
        //    return await Session.LoadAsync<FlickrFeed>(id);
        //}

        public IEnumerable<FeedModel> Get()
        {
            return feedRepository.GetFeeds();
        }
 


        


    }
}
