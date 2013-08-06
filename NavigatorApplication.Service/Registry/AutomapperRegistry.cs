namespace NavigatorApplication.Service.Registry
{
    using AutoMapper;
    
    public class AutomapperRegistry
    {
        public static void Configure()
        {
            Mapper.Reset();
            Mapper.Initialize(x =>
            {
                x.AddProfile<FeedProfile>();

            });

            Mapper.AssertConfigurationIsValid();


            Mapper.AssertConfigurationIsValid();
        }

    }
}