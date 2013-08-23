namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Web.Http;
    using NavigatorApplication.Service.Repository;
    
    public class FeedPhotoController : ApiController
    {
        private readonly IFeedRepository _feedRepository;

        public FeedPhotoController(IFeedRepository feedRepository)
        {
            _feedRepository = feedRepository;
        }


    }
}
