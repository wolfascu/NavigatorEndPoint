using System;
using System.Collections.Generic;

namespace NavigatorApplication.Service.DTO.Flickr.Interface
{
    /// <summary>
    /// Represents boundry definations for Flicker Feed Response
    /// </summary>
    public interface IFlickerFeed
    {

        string Title { get; set; }

        string Id { get; set; }

        DateTime UpdatedDate { get; set; }

        List<FeedEntry> Entries { get; set; }

    }
}
