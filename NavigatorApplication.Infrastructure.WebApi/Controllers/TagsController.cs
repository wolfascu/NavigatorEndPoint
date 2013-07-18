using NavigatorApplication.Common.Helpers;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System;
    using System.Linq;
    using NavigatorApplication.Infrastructure.WebApi.Model;
    using NavigatorApplication.Service.DTO.AtomPub;

    public class TagsController : BlogControllerBase
    {
        // GET api/tags
        public PublicationCategoriesDocument Get()
        {
            var tags = posts.SelectMany(p => p.Tags)
                .Distinct(StringComparer.InvariantCultureIgnoreCase)
                .Select(t => new TagModel { Name = t, Slug = t.ToSlug() });

            var doc = new PublicationCategoriesDocument(
                Url.Link("DefaultApi", new { controller = "tags" }),
                tags,
                isFixed: false
            );

            return doc;
        }
    }
}
