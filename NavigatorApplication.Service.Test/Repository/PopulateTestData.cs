using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using NUnit.Framework;
using NavigatorApplication.Service.DTO.Flickr;
using NavigatorApplication.Service.RavenDbDocuments;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace NavigatorApplication.Service.Test.Repository
{
    [TestFixture, Explicit]
    public class PopulateTestData
    {
        [Test]
        public void PopulateDataInStandaloneDatabase()
        {
            PopulateDataFromXml(new DocumentStore { ConnectionStringName = "RavenDb" }.Initialize());
        }

        [Test]
        public void EmbeddedRavenDb_InMemory_Example()
        {
            var embeddedRamDocumentStore = new EmbeddableDocumentStore
                {
                    RunInMemory = true
                }.Initialize();

            using (embeddedRamDocumentStore)
            {
                PopulateDataFromXml(embeddedRamDocumentStore);

                using (var session = embeddedRamDocumentStore.OpenSession())
                {
                    var feeds = session.Query<Feed>().ToList();

                    Console.WriteLine("Read {0} feed(s) from the volatile embedded database. Their Ids and Titles are:");

                    foreach (var feed in feeds)
                        Console.WriteLine("\t{0}: {1}", feed.Id, feed.Title);
                }
            }
        }

        [Test]
        public void EmbeddedRavenDb_OnDisk_Example()
        {
            var embeddedDiskDocumentStore = new EmbeddableDocumentStore
                {
                    RunInMemory = false,
                    DataDirectory = "Data"
                }.Initialize();

            using (embeddedDiskDocumentStore)
            {
                PopulateDataFromXml(embeddedDiskDocumentStore);

            }
        }



        public static void PopulateDataFromXml(IDocumentStore documentStore)
        {
            var dataFromXml = new XmlDataReader().ReadXmls().ToList();

            var feedDocuments = dataFromXml.Select(Mapper.DynamicMap<Feed>).ToList();

            using (var session = documentStore.OpenSession())
            {
                foreach (var feed in feedDocuments)
                    session.Store(feed);

                session.SaveChanges();
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