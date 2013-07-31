namespace NavigatorApplication.Service.DTO.Flickr.Interface
{
    using System;
    using System.Collections.Generic;

    public interface IFlickrFeed
    {
        string Title { get; set; }

        string Id { get; set; }

        DateTime UpdatedDate { get; set; }

        List<FeedEntry> Entries { get; set; }

    }
}
