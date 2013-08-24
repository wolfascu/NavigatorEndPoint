namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using NavigatorApplication.Service.Model;
    using NavigatorApplication.Service.Repository;

    public class FeedPhotoController : ApiController
    {
        private readonly IFeedRepository feedRepository;

        public FeedPhotoController(IFeedRepository feedRepository)
        {
            this.feedRepository = feedRepository;
        }

        public IEnumerable<PhotoEntryModel> Get(string id)
        {
            return feedRepository.GetPhotoEntries(id).ToList();
        }
    }

}
