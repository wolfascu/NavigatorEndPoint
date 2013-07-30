using FlickrNet;

namespace NavigatorApplication.Service.Test.FlickrService
{
    using Microsoft.Practices.Unity;

    using NavigatorApplication.Common.DI;
    using NavigatorApplication.Service.FlickrService;
    using NavigatorApplication.Service.Test.Helpers;

    using NUnit.Framework;
    using System;

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
        public void Can_Get_List_of_Subscriptions()
        {
            var topics = pushService.GetSubscriptions();
            foreach (var topic in topics)
            {
                Console.WriteLine(topic.Topic + " " + topic.Callback);
            }
        }

        [Test]
        public void Can_Subscribe_UnSubscribe()
        {
            var callback = "http://tuanmh.no-ip.biz/flickratom/api/AtomEndpoint";
            var topic = "my_photos";
            var lease = 0;
            var verify = "sync";

            var f = new Flickr();
            f.PushSubscribe(topic, callback, verify, null, lease, null, null, 0, 0, 0, FlickrNet.RadiusUnit.None, FlickrNet.GeoAccuracy.None, null, null);

            var subscriptions = f.PushGetSubscriptions();

            bool found = false;

            foreach (var sub in subscriptions)
            {
                if (sub.Topic == topic && sub.Callback == callback)
                {
                    found = true;
                    break;
                }
            }

            Assert.IsTrue(found, "Should have found subscription.");

            f.PushUnsubscribe(topic, callback, verify, null);
        }


        public void Test()
        {
            var f = new Flickr();
            //var frog = f.AuthGetFrob();
            //Console.WriteLine(frog);
            //f.AuthCalcUrlMobile(frog, AuthLevel.Delete);
            var token = f.AuthGetToken("72157634849262138-12c5eb8e23fc53d0-205197").Token;
            Console.WriteLine(token);
            //System.Diagnostics.Process.Start(f.AuthCalcUrlMobile(frog, AuthLevel.Delete));
        }





    }
}
