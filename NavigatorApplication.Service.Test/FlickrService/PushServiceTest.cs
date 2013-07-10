using System;
using NavigatorApplication.Common.DI;
using NavigatorApplication.Service.FlickrService;
using NavigatorApplication.Service.Test.Helpers;

namespace NavigatorApplication.Service.Test.FlickrService
{
    using FlickrNet;

    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    [TestFixture]
    public class PushServiceTest
    {
        private IPushService pushService;
        
        [SetUp]
        public void Setup()
        {
            IoC.Container.RegisterType<IPushService, PushService>();

            pushService = IoC.Container.Resolve<IPushService>();
        }

        [Test]
        public void Can_Get_List_of_Topics()
        {
            var topics = pushService.PushGetTopics();
            foreach (var topic in topics)
            {
                Console.WriteLine(topic);
            }
        }

        [Test]
        public void Can_Subscribe_UnSubscribe()
        {
            var callback = "http://www.wackylabs.net/dev/push/test.php";
            var topic = "contacts_photos";
            var lease = 0;
            var verify = "sync";

            var f = FlickrHelpers.GetAuthInstance();
            f.PushSubscribe(topic, callback, verify, null, lease, null, null, 0, 0, 0, FlickrNet.RadiusUnit.None, FlickrNet.GeoAccuracy.None, null, null);

            Assert.Fail("TODO");
        }


        public void Test()
        {
            
        }





    }
}
