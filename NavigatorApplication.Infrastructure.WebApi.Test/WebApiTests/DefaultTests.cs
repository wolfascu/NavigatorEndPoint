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
        public void SetUp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["serviceBaseUri"]);
            
        }

        [Test]
        public void Get_Response_Is_Success()
        {
            response = client.GetAsync("DefaultApi/get").Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void Get_Response_Is_Not_Found()
        {
            response = client.GetAsync("DefaultApi/get/1").Result;
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public void GetResponseIsJson()
        {
            response = client.GetAsync("DefaultApi/get").Result;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
        }

    }
}
