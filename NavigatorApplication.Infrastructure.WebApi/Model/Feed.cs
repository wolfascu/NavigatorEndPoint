namespace NavigatorApplication.Infrastructure.WebApi.Model
{
    using System;
    using System.Collections.Generic;
    using NavigatorApplication.Service.DTO.AtomPub;
    using NavigatorApplication.Service.DTO.Links;

    public class Feed : IPublicationCommand
    {
        public Feed()
        {
            PublishDate = DateTime.UtcNow;
            Tags = new string[0];
        }


        public string Id { get; set; }


        public string Title { get; set; }


        public DateTime Updated { get; set; }

        public IEnumerable<Entry> Entry { get; set; }

        public string Slug { get; set; }
        public string Summary { get; set; }
        public string ContentType { get; set; }
        public DateTime LastUpdated { get; set; }

        public string Content { get; set; }
        public string[] Tags { get; set; }
        public DateTime? PublishDate { get; set; }
        public string[] Categories { get; set; }

        public string CategoriesScheme { get; private set; }
        public IEnumerable<Link> Links { get; private set; }

        public string Xml { get; set; }

    }


    public class Entry 
    {
        public string Title { get; set; }

        public string Id { get; set; }

        public IList<string> UpdateType { get; set; }

        public string PhotoId { get; set; }

        public string Tag { get; set; }
      
    }



}