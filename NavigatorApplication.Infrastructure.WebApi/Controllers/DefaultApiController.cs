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
            return "value";
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public PostResponse Post([FromBody]Person aPerson)
        {
            var responseObj = new PostResponse();
            if (aPerson == null)
            {
                responseObj.ResponseText = "aPerson is null";
                return responseObj;
            }

            if (aPerson.FirstName == null)
            {
                responseObj.ResponseText = "First Name is null";
                return responseObj;
            }

            responseObj.ResponseText = string.Format("The first name is {0}", aPerson.FirstName);
            return responseObj;
        }
    }
}
