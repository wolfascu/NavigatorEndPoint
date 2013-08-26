using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using NavigatorApplication.Service.DTO.Flickr;
using NavigatorApplication.Service.RavenDbModels;
using Raven.Client.Document;

namespace NavigatorApplication.Service.Test.Repository
{
    [TestFixture, Explicit]
    public class PopulateTestData
    {
        [Test]
        public void PopulateDataFromXml()
        {
            var dataFromXml = new XmlDataReader().ReadXmls();

            var dataMapper = new XmlToRavenEntitiesMapper(dataFromXml);

            using (var ds = new DocumentStore { ConnectionStringName = "RavenDb" }.Initialize())
            using (var session = ds.OpenSession())
            {
                foreach (var feed in dataMapper.GetFeeds())
                    session.Store(feed);

                foreach (var photoEntryModel in dataMapper.GetPhotos())
                    session.Store(photoEntryModel);

                session.SaveChanges();
            }
        }




        internal class XmlToRavenEntitiesMapper
        {
            private readonly List<FlickrFeed> feedData;

            public XmlToRavenEntitiesMapper(IEnumerable<FlickrFeed> feedData)
            {
                this.feedData = feedData.OrderBy(f => f.UpdatedDate).ToList();
            }

            public IEnumerable<Feed> GetFeeds()
            {
                return feedData.Select(x => new Feed
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Date = x.UpdatedDate,
                        Operation = x.DeletedEntry == null ? "Update" : "Delete"
                    });
            }

            public IEnumerable<Photo> GetPhotos()
            {
                var photos = feedData.SelectMany(
                    f =>
                    f.Entries.Select(e =>
                                     new Photo
                                         {
                                             FeedId = f.Id,
                                             Id = e.Id.TrimStart('/'),
                                             Title = e.Title,
                                             DateTaken = e.DateTaken,
                                             AuthorName = e.Author.Name,
                                             AuthorURL = e.Author.Url,
                                             Updated = e.UpdatedDate,
                                             PhotoURL = e.MediaContent.Url
                                         })
                    );

                return SelectLatestVersionOfEachPhoto(photos);
            }

            private static IEnumerable<Photo> SelectLatestVersionOfEachPhoto(IEnumerable<Photo> photos)
            {
                return from photo in photos
                       group photo by photo.Id
                       into g
                       select g.Last();
            }
        }

        internal class XmlDataReader
        {
            private const string XmlPath = "../../../XML";

            public IEnumerable<FlickrFeed> ReadXmls()
            {
                //var file = new FileInfo(Path.Combine(XmlPath, "1376803613.xml"));

                var deserializer = new XmlSerializer(typeof(FlickrFeed));

                foreach (var file in Directory.EnumerateFiles(XmlPath, "*.xml"))
                {
                    yield return (FlickrFeed)deserializer.Deserialize(new XmlTextReader(file));
                }
            }
        }
    }
}
