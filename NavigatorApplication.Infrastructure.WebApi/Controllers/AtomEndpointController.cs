namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using NavigatorApplication.Service.DTO;
    using NavigatorApplication.Service.Repository;

    public class AtomEndpointController : ApiController
    {
        //Create Atom Endpoint to Recieve Flickr Feeds
        //http://ben.onfabrik.com/posts/atompub-aspnet-web-api-part1
        
        private readonly IFeedRepository feedRepository;

        public AtomEndpointController(IFeedRepository urlRepository)
        {
            this.feedRepository = urlRepository;
        }

        public IEnumerable<Feed> Get()
        {
            return feedRepository.GetAll();
        }

        public Feed Get(string id)
        {
            return feedRepository.Get(id);
        }

        public void Post(string value)
        {
        }

        public void Put(int id, string value)
        {
        }

        public void Delete(string id)
        {
        }

    }
}
