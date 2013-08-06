namespace NavigatorApplication.Service.FlickrService
{
    using System;
    using System.Collections.Generic;
    using FlickrNet;

    public class SearchService : ISearchService
    {
        private readonly Flickr flickr;

        public SearchService()
        {
            this.flickr = new Flickr();
        }

        public PhotoInfo GetPhotoInfo(string photoId)
        {
            var photoInfo = flickr.PhotosGetInfo(photoId);
            return photoInfo;
        }

        public IList<PhotoInfo> GetPhotoInfoList(IEnumerable<string> photoIdList)
        {
            throw new NotImplementedException();
        }
    }
}
