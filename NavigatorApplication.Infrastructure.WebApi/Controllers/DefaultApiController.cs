namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class DefaultApiController : ApiController
    {
        public string Get(int id)
        {
            if(id == 1)
              throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return "value";
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
