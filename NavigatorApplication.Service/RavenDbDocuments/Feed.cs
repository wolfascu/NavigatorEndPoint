using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NavigatorApplication.Service.RavenDbDocuments
{
    public class Feed
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime UpdatedDate { get; set; }

        public List<Entry> Entries { get; set; }
    }

    public class Entry
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Content Content { get; set; }

        public Author Author { get; set; }

        public List<Category> Categories { get; set; }

        public string WoeId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Point { get; set; }

        public DateTime DateTaken { get; set; }

        public string Safety { get; set; }

        //public List<FlickrUpdate> Updates { get; set; }

        public string MediaTitle { get; set; }

        //public MediaCredit MediaCredit { get; set; }

        //public MediaContent MediaContent { get; set; }

        //public List<MediaThumbnail> MediaThumbnails { get; set; }

        //public List<Link> Links { get; set; }
    }

    public class Content
    {
        public string Type { get; set; }
        public string Body { get; set; }
    }
    public class Author
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
        public string IconUrl { get; set; }
    }
    public class Category
    {
        public string Term { get; set; }
        public string Scheme { get; set; }
    }
}