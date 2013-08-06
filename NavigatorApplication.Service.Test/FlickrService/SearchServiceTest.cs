using System;

namespace NavigatorApplication.Service.Test.FlickrService
{
    using NUnit.Framework;
    using NavigatorApplication.Common.DI;

    using Microsoft.Practices.Unity;

    using NavigatorApplication.Service.FlickrService;

    [TestFixture]
    public class SearchServiceTest
    {
        private ISearchService searchService;
        
        [SetUp]
        public void Setup()
        {
            IoC.Container.RegisterType<ISearchService, SearchService>();
            searchService = IoC.Container.Resolve<ISearchService>();
        }

        [Test]
        [TestCase("9250911801")]
        public void Can_Get_Photo_MachineKeys(string photoId)
        {
            var photoInfo = searchService.GetPhotoInfo(photoId);
            foreach (var tag in photoInfo.Tags)
            {
                Console.WriteLine(tag.IsMachineTag);
            }
        }

        //TODO - Get List of Machine Keys

        [Test]
        public void Can_Get_PhotoList_MachineKeys_Async()
        {
            var photoIdList = PhotoIdList();

            //foreach (var photo in photos)
            //{
            //    Console.WriteLine(photo);
            //}

            // var permissions = searchService.GetPhotoInfoListAsync(photos);

            Assert.Fail("TODO");
        }

        private string[] PhotoIdList()
        {
            //1st Key is Invalid
            string[] arr1 = new[] { "9999999999", "5966022670", "5966022914", "5988938839", "5989498210", "5989498400", "5989498572", "5965468387", "5966024480", };
            return arr1;
        }

    }
}
