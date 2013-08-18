namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using NavigatorApplication.Service.DTO.Flickr;

    public class FlickrServiceController : RavenController
    {
        public HttpResponseMessage Get(string challenge)
        {          
            var response = Request.CreateResponse();
            response.Content = new StringContent(challenge);           
            return response;
        }

        public async Task<HttpResponseMessage> Post(FlickrFeed flickrFeed)
        {
            await Session.StoreAsync(flickrFeed);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}