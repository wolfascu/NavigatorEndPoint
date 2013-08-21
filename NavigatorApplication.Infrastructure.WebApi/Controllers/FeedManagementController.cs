using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Raven.Client.Linq.Indexing;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Collections.Generic;

    using Service.Model;
    using Service.Repository;

    public class FeedManagementController : ApiController
    {
        private readonly IFeedRepository _feedRepository;
        
        public FeedManagementController(IFeedRepository feedRepository)
        {
            _feedRepository = feedRepository;
        }

        //public async Task<FlickrFeed> Get(string id)
        //{
        //    var test = id;
        //    return await Session.LoadAsync<FlickrFeed>(id);
        //}

        public IEnumerable<FeedModel> Get()
        {
            return _feedRepository.GetFeeds();
        }

    }
}
