namespace NavigatorApplication.Service.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NavigatorApplication.Service.DTO;

    public class FeedRepository : IFeedRepository
    {
        private List<Feed> _feeds = new List<Feed>();
        private int _nextId = 1;

        public FeedRepository()
        {
            //this.Add(new Url()
            //{
            //    UrlId = 1,
            //    Address = "http://www.strathweb.com/2012/03/build-facebook-style-infinite-scroll-with-knockout-js-and-last-fm-api/",
            //    Title = "Build Facebook style infinite scroll with knockout.js and Last.fm API",
            //    CreatedBy = "Filip",
            //    CreatedAt = new DateTime(2012, 3, 20),
            //    Description = "Since knockout.js is one of the most amazing and innovative pieces of front-end code I have seen in recent years, I hope this is going to help you a bit in your everday battles. In conjuction with Last.FM API, we are going to create an infinitely scrollable history of your music records – just like the infinite scroll used on Facebook or on Twitter."
            //});
            //this.Add(new Url()
            //{
            //    UrlId = 2,
            //    Address = "http://www.strathweb.com/2012/04/your-own-sports-news-site-with-espn-api-and-knockout-js/",
            //    Title = "Your own sports news site with ESPN API and Knockout.js",
            //    CreatedBy = "Filip",
            //    CreatedAt = new DateTime(2012, 4, 8),
            //    Description = "You will be able to browse the latest news from ESPN from all sports categories, as well as filter them by tags. The UI will be powered by KnockoutJS and Twitter bootstrap, and yes, will be a single page. We have already done two projects together using knockout.js – last.fm API infinite scroll and ASP.NET WebAPI file upload. Hopefully we will continue our knockout.js adventures in an exciting, and interesting for you, way."
            //});
        }
    
        public IQueryable<Feed> GetAll()
        {
            return _feeds.AsQueryable();
        }

        public Feed Get(string id)
        {
            return _feeds.Find(i => i.Id == id);
        }

        public Feed Add(Feed feed)
        {
            feed.Id = (_nextId++).ToString();
            _feeds.Add(feed);
            
            return feed;
        }

        public void Remove(string id)
        {
            Feed feed = _feeds.Find(i => i.Id == id);
            _feeds.Remove(feed);
        }

        public void Update(Feed feed)
        {
            int index = _feeds.FindIndex(i => i.Id == feed.Id);

            _feeds.RemoveAt(index);
            _feeds.Add(feed);
        }
    }
}
