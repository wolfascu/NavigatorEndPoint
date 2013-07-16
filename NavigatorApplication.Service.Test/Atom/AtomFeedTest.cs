using NavigatorApplication.Service.Repository;

namespace NavigatorApplication.Service.Test.Atom
{
    using Microsoft.Practices.Unity;
    using NavigatorApplication.Service.DTO;
    using NavigatorApplication.Common.DI;
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
        public void Can_Get_Url_Repository_Urls()
        {
            var urls = urlRepository.GetAll();
            foreach (var url in urls)
            {
                Console.WriteLine(url.Title);  
            }
        }


        [Test]
        public void Can_Get_Url_Repository_Url()
        {
            var url = urlRepository.Get(1);
            Console.WriteLine(url.Title);
        }







    }
}
