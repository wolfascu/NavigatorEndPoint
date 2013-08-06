using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NavigatorApplication.Infrastructure.WebApi.Model;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
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

        public PostResponse Post([FromBody]Person person)
        {
            var response = new PostResponse();
            if (person == null)
            {
                response.ResponseText = "Person is null";
                return response;
            }

            if (person.FirstName == null)
            {
                response.ResponseText = "First Name is null";
                return response;
            }

            response.ResponseText = string.Format("The first name is {0}", person.FirstName);
            
            return response;
        }
    }
}
