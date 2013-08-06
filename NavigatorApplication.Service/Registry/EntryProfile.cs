namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Registry
{
    public class EntryProfile 
    {
        public const string Profile = "EntryProfile";

        public string ProfileName
        {
            get
            {
                return Profile;
            }
        }

        protected void Configure()
        {
          /*  Mapper.CreateMap<SyndicationItem, Entry>()                
                .ForMember(feed => feed.UpdateType, expression => expression.Ignore())                
                .WithProfile(Profile);*/
            //base.Configure();
        }
    }
}