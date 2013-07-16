﻿using NavigatorApplication.Service.Repository;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using NavigatorApplication.Service.DTO;
    
    public class AtomEndpointController : ApiController
    {
        //RSS & Atom MediaTypeFormatter for ASP.NET WebAPI
        //http://www.strathweb.com/2012/04/rss-atom-mediatypeformatter-for-asp-net-webapi

        //Create Atom Endpoint to Recieve Flickr Feeds
        //http://ben.onfabrik.com/posts/atompub-aspnet-web-api-part1

        private readonly IUrlRepository urlRepository;

        public AtomEndpointController(IUrlRepository urlRepository)
        {
            this.urlRepository = urlRepository;
        }

        public IEnumerable<Url> Get()
        {
            //return new string[] { "value1", "value2" };
            return urlRepository.GetAll();
        }

        public Url Get(int id)
        {
            return urlRepository.Get(id);
        }

        public void Post(string value)
        {
        }

        public void Put(int id, string value)
        {
        }

        public void Delete(int id)
        {
        }

    }
}
