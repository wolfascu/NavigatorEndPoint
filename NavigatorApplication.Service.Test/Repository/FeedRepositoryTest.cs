using System;
using NavigatorApplication.Service.Repository;
using Microsoft.Practices.Unity;
using NavigatorApplication.Common.DI;
using NUnit.Framework;

namespace NavigatorApplication.Service.Test.Repository
{
    [TestFixture]
    public class FeedRepositoryTest
    {
        private IFeedRepository feedRepository;

        [SetUp]
        public void Setup()
        {
            IoC.Container.RegisterType<IFeedRepository, FeedRepository>();
            feedRepository = IoC.Container.Resolve<IFeedRepository>();
        }

        [Test]
        public void Can_Get_Feeds()
        {
            var feeds = feedRepository.GetFeeds();
            foreach (var feedModel in feeds)
            {
                Console.WriteLine(feedModel.ToString());
            }
        }

        [Test]
        [TestCase("1373428650")]
        public void Can_Get_Feed_Photo_Entries(string feedId)
        {
            var photoEntries = feedRepository.GetPhotoEntries(feedId);
            foreach (var photoEntryModel in photoEntries)
            {
                Console.WriteLine(photoEntryModel.ToString());
            }
        }





    }
}
