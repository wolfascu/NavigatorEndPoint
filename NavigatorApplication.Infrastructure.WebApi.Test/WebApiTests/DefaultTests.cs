using System;
using NUnit.Framework;
using System.Net.Http;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers; 


namespace NavigatorApplication.Infrastructure.WebApi.Test.WebApiTests
{
    [TestFixture]
    public class DefaultTests
    {
        private HttpClient client;
        private HttpResponseMessage response;

        [SetUp]
        public void SetUP()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["serviceBaseUri"]);
            response = client.GetAsync("DefaultApi/get").Result;
        }

        [Test]
        public void GetResponseIsSuccess()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [Test]
        public void GetResponseIsJson()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
        }

        [Test]
        public void GetAuthenticationStatus()
        {
            Assert.AreNotEqual(HttpStatusCode.Unauthorized, response.StatusCode);

        } 
    }
}
