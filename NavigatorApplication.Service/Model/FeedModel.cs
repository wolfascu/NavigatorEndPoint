namespace NavigatorApplication.Service.Model
{
    using System;

    public class FeedModel
    {
        public string Id { get; set; }

        public string Operation { get; set; }

        public string Title { get; set; }

        public int Entries { get; set; }

        public DateTime Date { get; set; }

    }
}
