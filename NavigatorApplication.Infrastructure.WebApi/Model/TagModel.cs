using NavigatorApplication.Service.DTO.AtomPub;

namespace NavigatorApplication.Infrastructure.WebApi.Model
{
    public class TagModel : IPublicationCategory
    {
        public string Name { get; set; }
        public string Slug { get; set; }

        string IPublicationCategory.Label
        {
            get { return Name; }
        }
    }
}