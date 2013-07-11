using System.Collections.Generic;
using FlickrNet;

namespace NavigatorApplication.Service.FlickrService
{
    public interface ISearchService
    {
        PhotoInfo GetPhotoInfo(string photoId);

        IList<PhotoInfo> GetPhotoInfoList(IEnumerable<string> photoIdList);
    }
}
