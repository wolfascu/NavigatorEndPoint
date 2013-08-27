namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using NavigatorApplication.Service.DTO.Flickr;
    using NavigatorApplication.Infrastructure.WebApi.Extensions.Filter;

    public class FlickrServiceController : RavenController
    {
        [TokenValidation]
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