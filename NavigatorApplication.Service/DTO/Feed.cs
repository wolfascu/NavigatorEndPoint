using System;
using System.Collections.Generic;

namespace NavigatorApplication.Service.DTO
{
    public class Feed
    {
        public string Id { get; set; }
        
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public List<Entry> Entries { get; set; }
    }

    public class Entry
    {
        public string Id { get; set; }
        
        public string Title { get; set; }

        public DateTime Published { get; set; }

        public DateTime Updated { get; set; }

        public Author Author { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }

        public string Uri { get; set; }
    }






}
