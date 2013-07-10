namespace NavigatorApplication.Service.FlickrService
{
    using System;
    using FlickrNet;

    public class PushService : IPushService
    {
        private readonly Flickr flickr;
        
        public PushService()
        {
            this.flickr = new Flickr(); 
        }

        public string[] PushGetTopics()
        {
            return flickr.PushGetTopics();
        }
    }
}
