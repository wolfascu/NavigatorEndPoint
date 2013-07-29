using FlickrNet;

namespace NavigatorApplication.Service.FlickrService
{
    public interface IPushService
    {
        string[] PushGetTopics();

        SubscriptionCollection GetSubscriptions();


    }
}
