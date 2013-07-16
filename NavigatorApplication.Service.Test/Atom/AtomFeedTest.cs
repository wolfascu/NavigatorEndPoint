namespace NavigatorApplication.Service.Test.Atom
{
    using Microsoft.Practices.Unity;
    using NavigatorApplication.Service.DTO;
    using NavigatorApplication.Common.DI;
    using NavigatorApplication.Service.FlickrService;
    using NavigatorApplication.Service.Test.Helpers;

    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AtomFeedTest
    {
        private IUrlRepository urlRepository;

        [SetUp]
        public void Setup()
        {
            IoC.Container.RegisterType<IUrlRepository, UrlRepository>();
            urlRepository = IoC.Container.Resolve<IUrlRepository>();
        }

        [Test]
        public void Can_Get_List_of_Topics()
        {
            var url = urlRepository.Get(1);
            Console.WriteLine(url.Title);
        }







    }
}
