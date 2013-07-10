namespace NavigatorApplication.Service.Test.Parser
{
    using System;
    using System.ServiceModel.Syndication;
    using System.Xml;
    
    using NUnit.Framework;

    [TestFixture]
    public class AtomFeedTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Can_Read_Atom_Feed()
        {
            var formatter = new Atom10FeedFormatter();

            using (var reader = XmlReader.Create("../../../XML/people07102013055734.xml"))
            {
                formatter.ReadFrom(reader);
            }

            foreach (SyndicationItem item in formatter.Feed.Items)
            {
                Console.WriteLine("PhotoId:" + item.Id+ "|" + "" + item.Title.Text + " " + item.LastUpdatedTime);
            }

        }
    }
}
