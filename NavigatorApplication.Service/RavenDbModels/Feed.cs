using System;

namespace NavigatorApplication.Service.RavenDbModels
{
    public class Feed
    {
        public string Id { get; set; }

        public string Operation { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }
    }
}