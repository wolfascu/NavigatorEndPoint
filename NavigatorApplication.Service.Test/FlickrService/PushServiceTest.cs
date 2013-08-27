using System.Collections.Generic;
using FlickrNet;
//using FlickrNetTest;

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
        // todo: temporarily commented out. Does not compile due to missing FlickrService\TestData.cs file

        //private IPushService pushService;
        
        //[SetUp]
        //public void Setup()
        //{
        //    IoC.Container.RegisterType<IPushService, PushService>();

        //    pushService = IoC.Container.Resolve<IPushService>();
        //}

        //[Test]
        //public void Can_Get_List_of_Topics()
        //{
        //    var topics = pushService.PushGetTopics();
        //    foreach (var topic in topics)
        //    {
        //        Console.WriteLine(topic);
        //    }
        //}

        //[Test]
        //public void Can_Get_List_of_Subscriptions()
        //{
        //    var topics = pushService.GetSubscriptions();
        //    foreach (var topic in topics)
        //    {
        //        Console.WriteLine(topic.Topic + " " + topic.Callback);
        //    }
        //}

        //[Test]
        //public void Can_Subscribe_UnSubscribe()
        //{
        //    var callback = "http://tuanmh.no-ip.biz/flickratom/api/AtomEndpoint";
        //    var topic = "my_photos";
        //    var lease = 0;
        //    var verify = "sync";

        //    var f = new Flickr();
        //    f.OAuthAccessToken = "72157635238244890-ff2d8c884cd53a93";
        //    f.OAuthAccessTokenSecret = "f2065ac65bf7dda7";
        //    f.PushSubscribe(topic, callback, verify, null, lease, null, null, 0, 0, 0, FlickrNet.RadiusUnit.None, FlickrNet.GeoAccuracy.None, null, null);

        //    var subscriptions = f.PushGetSubscriptions();

        //    bool found = false;

        //    foreach (var sub in subscriptions)
        //    {
        //        if (sub.Topic == topic && sub.Callback == callback)
        //        {
        //            found = true;
        //            break;
        //        }
        //    }

        //    Assert.IsTrue(found, "Should have found subscription.");

        //    f.PushUnsubscribe(topic, callback, verify, null);
        //}

        //[Test]
        //public void Test()
        //{
        //    var f = new Flickr();
        //    //f.OAuthGetRequestToken
        //    var frog = f.AuthGetFrob();
        //    Console.WriteLine(frog);
        //    f.AuthCalcUrlMobile(frog, AuthLevel.Delete);            
        //    //var token = f.AuthGetToken("72157634849262138-12c5eb8e23fc53d0-205197").Token;
        //    //Console.WriteLine(token);
        //    System.Diagnostics.Process.Start(f.AuthCalcUrlMobile(frog, AuthLevel.Delete));
        //}


        //[Test]
        //public void OAuthGetRequestTokenBasicTest()
        //{
        //    Flickr f = TestData.GetSignedInstance();

        //    string callback = "oob";

        //    OAuthRequestToken requestToken = f.OAuthGetRequestToken(callback);

        //    Assert.IsNotNull(requestToken);
        //    Assert.IsNotNull(requestToken.Token, "Token should not be null.");
        //    Assert.IsNotNull(requestToken.TokenSecret, "TokenSecret should not be null.");

        //    System.Diagnostics.Process.Start(f.OAuthCalculateAuthorizationUrl(requestToken.Token, AuthLevel.Delete));

        //    Console.WriteLine("token = " + requestToken.Token);
        //    Console.WriteLine("token secret = " + requestToken.TokenSecret);

        //    TestData.RequestToken = requestToken.Token;
        //    TestData.RequestTokenSecret = requestToken.TokenSecret;
        //}

        //[Test]
        //[Ignore]
        //public void OAuthGetAccessTokenBasicTest()
        //{
        //    Flickr f = TestData.GetSignedInstance();

        //    OAuthRequestToken requestToken = new OAuthRequestToken();
        //    requestToken.Token = TestData.RequestToken;
        //    requestToken.TokenSecret = TestData.RequestTokenSecret;
        //    string verifier = "122-667-631";

        //    OAuthAccessToken accessToken = f.OAuthGetAccessToken(requestToken, verifier);

        //    Console.WriteLine("access token = " + accessToken.Token);
        //    Console.WriteLine("access token secret = " + accessToken.TokenSecret);

        //    TestData.AccessToken = accessToken.Token;
        //    TestData.AccessTokenSecret = accessToken.TokenSecret;
        //}

        //[Test]
        //public void OAuthPeopleGetPhotosBasicTest()
        //{
        //    Flickr f = TestData.GetAuthInstance();

        //    PhotoCollection photos = f.PeopleGetPhotos("me");
        //}

        //[Test]
        //[ExpectedException(typeof(OAuthException))]
        //public void OAuthInvalidAccessTokenTest()
        //{
        //    Flickr.CacheDisabled = true;

        //    Flickr f = TestData.GetInstance();
        //    f.ApiSecret = "asdasd";
        //    f.OAuthGetRequestToken("oob");
        //}

        //[Test]
        //public void OAuthCheckTokenTest()
        //{
        //    Flickr f = TestData.GetAuthInstance();

        //    Auth a = f.AuthOAuthCheckToken();

        //    Assert.AreEqual(a.Token, f.OAuthAccessToken);
        //}

        //[Test]
        //public void OAuthCheckEncoding()
        //{
        //    // Test cases taken from OAuth spec
        //    // http://wiki.oauth.net/w/page/12238556/TestCases
        //    var test = new Dictionary<string, string>()
        //    {
        //        { "abcABC123", "abcABC123" },
        //        { "-._~", "-._~"},
        //        {"%", "%25"},
        //        { "+", "%2B"},
        //        { "&=*", "%26%3D%2A"},
        //        { "", ""},
        //        { "\u000A", "%0A"},
        //        { "\u0020", "%20"},
        //        { "\u007F", "%7F"},
        //        { "\u0080", "%C2%80"},
        //        { "\u3001", "%E3%80%81"},
        //        { "$()", "%24%28%29"}
        //    };

        //    /*foreach (var pair in test)
        //    {
        //        Assert.AreEqual(pair.Value, UtilityMethods.EscapeOAuthString(pair.Key));
        //    }*/
        //}



    }
}
