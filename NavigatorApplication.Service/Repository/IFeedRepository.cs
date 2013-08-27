namespace NavigatorApplication.Service.Repository
{
    using NavigatorApplication.Service.Model;
    using System.Collections.Generic;

    public interface IFeedRepository
    {
        IEnumerable<FeedModel> GetFeeds();

        IEnumerable<PhotoEntryModel> GetPhotoEntries(string feedId);
    }
}

