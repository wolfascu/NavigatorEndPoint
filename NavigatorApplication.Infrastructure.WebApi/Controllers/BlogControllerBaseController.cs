namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using NavigatorApplication.Infrastructure.WebApi.Model;
    
    public abstract class BlogControllerBase : ApiController
    {
        protected static readonly List<Post> posts = new List<Post>();
    }
}
