using NavigatorApplication.Service.Repository;

namespace NavigatorApplication.Service.Test.Atom
{
    using Microsoft.Practices.Unity;
    using NavigatorApplication.Common.DI;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AtomFeedTest
    {
        private IFeedRepository feedRepository;

        [SetUp]
        public void Setup()
        {
            IoC.Container.RegisterType<IFeedRepository, FeedRepository>();
            feedRepository = IoC.Container.Resolve<IFeedRepository>();
        }

        [Test]
        public void Can_Get_Url_Repository_Urls()
        {
            var urls = feedRepository.GetAll();
            foreach (var url in urls)
            {
                Console.WriteLine(url.Title);  
            }
        }


        [Test]
        public void Can_Get_Url_Repository_Url()
        {
            var feed = feedRepository.Get("1");
            Console.WriteLine(feed.Title);
        }
    }
}
