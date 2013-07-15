using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NavigatorApplication.Service.DTO;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    public class AtomEndpointController : ApiController
    {
        static readonly IUrlRepository _repo = new UrlRepository();
        
        //RSS & Atom MediaTypeFormatter for ASP.NET WebAPI
        //http://www.strathweb.com/2012/04/rss-atom-mediatypeformatter-for-asp-net-webapi

        //Create Atom Endpoint to Recieve Flickr Feeds
        //http://ben.onfabrik.com/posts/atompub-aspnet-web-api-part1


        // GET /api/values
        public IEnumerable<Url> Get()
        {
            //return new string[] { "value1", "value2" };
            return _repo.GetAll();
        }

        // GET /api/values/5
        public Url Get(int id)
        {
            return _repo.Get(id);
        }

        // POST /api/values
        public void Post(string value)
        {
        }

        // PUT /api/values/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/values/5
        public void Delete(int id)
        {
        }



    }
}
