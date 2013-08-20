namespace NavigatorApplication.Service.Repository
{
    using System;
    using System.Collections.Generic;

    using NavigatorApplication.Service.Model;

    public class FeedRepository : IFeedRepository
    {
        private readonly List<FeedModel> feeds;

        public FeedRepository()
        {
            feeds = new List<FeedModel>()
                {
                   new FeedModel{Operation ="Update", Id = "1373428650", Title = "Flickr Push Feed", Entries = 4, Date = DateTime.Parse("7/10/2013 4:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1373428328", Title = "Flickr Push Feed", Entries = 2, Date = DateTime.Parse("1/16/2013 6:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1973323430", Title = "Flickr Push Feed", Entries = 1, Date = DateTime.Parse("8/20/2013 4:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1373428321", Title = "Flickr Push Feed", Entries = 2, Date = DateTime.Parse("1/16/2013 8:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1573428652", Title = "Flickr Push Feed", Entries = 2, Date = DateTime.Parse("2/18/2013 12:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1273428323", Title = "Flickr Push Feed", Entries = 5, Date = DateTime.Parse("3/16/2013 11:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1173428654", Title = "Flickr Push Feed", Entries = 7, Date = DateTime.Parse("7/13/2013 2:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1773428325", Title = "Flickr Push Feed", Entries = 7, Date = DateTime.Parse("1/2/2013 8:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1327328656", Title = "Flickr Push Feed", Entries = 12, Date = DateTime.Parse("4/15/2013 5:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1473428327", Title = "Flickr Push Feed", Entries = 7, Date = DateTime.Parse("2/14/2013 11:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1573428658", Title = "Flickr Push Feed", Entries = 5, Date = DateTime.Parse("1/17/2013 9:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1773428391", Title = "Flickr Push Feed", Entries = 12, Date = DateTime.Parse("6/11/2013 12:52:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1873428602", Title = "Flickr Push Feed", Entries = 2, Date = DateTime.Parse("8/13/2013 12:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1973428321", Title = "Flickr Push Feed", Entries = 1, Date = DateTime.Parse("8/16/2013 5:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1673428663", Title = "Flickr Push Feed", Entries = 2, Date = DateTime.Parse("5/15/2013 3:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1372348121", Title = "Flickr Push Feed", Entries = 5, Date = DateTime.Parse("4/16/2013 8:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1843428212", Title = "Flickr Push Feed", Entries = 5, Date = DateTime.Parse("3/13/2013 3:57:30 AM")},
                   new FeedModel{Operation ="Update", Id = "1353428332", Title = "Flickr Push Feed", Entries = 12, Date = DateTime.Parse("6/7/2013 2:57:30 AM")},
                };
        }

        public IEnumerable<FeedModel> GetFeeds()
        {
            return feeds;
        }
    }
}
