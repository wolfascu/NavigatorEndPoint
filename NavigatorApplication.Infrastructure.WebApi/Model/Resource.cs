using System.Collections.Generic;
using NavigatorApplication.Common.Helpers;
using NavigatorApplication.Service.DTO.Links;

namespace NavigatorApplication.Infrastructure.WebApi.Model
{
    public abstract class Resource
    {
        private readonly List<Link> links;

        public IEnumerable<Link> Links { get { return links; } }

        public Resource()
        {
            links = new List<Link>();
        }

        public void AddLink(Link link)
        {
            Ensure.Argument.NotNull(link, "link");
            links.Add(link);
        }
    }
}