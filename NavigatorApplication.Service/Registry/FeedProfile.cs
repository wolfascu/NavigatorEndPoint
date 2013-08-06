namespace NavigatorApplication.Service.Registry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using AutoMapper;

    public class FeedProfile : Profile
    {
        public const string Profile = "FeedProfile";

        protected override void Configure()
        {
            Func<SyndicationItem, object> resolver = (item) =>
            {                                                             
              var updates = item.ElementExtensions.Where(extension => extension.OuterName.Equals("update"));
              var types = new List<string>();
             
                foreach (var extension in updates)
                {
                   var reader = extension.GetReader();
                   if (!string.IsNullOrEmpty(reader.GetAttribute("type")))
                   {
                      var type = reader.GetAttribute("type");
                      types.Add(type);
                   }
                 }
                                                            
                return types;
           };


            Func<SyndicationItem, object> tagResolver = (item) =>
            {
                if(item.Categories.Count > 0)
                {
                    return item.Categories[0].Name;
                }

                return string.Empty;
            };
            

            //Mapper.CreateMap<SyndicationItem, Entry>()
            //    .ForMember(feed => feed.UpdateType, expression => expression.Ignore())
            //    .ForMember(feed => feed.Title, opt => opt.MapFrom(item => item.Title.Text))
            //    .ForMember(feed => feed.UpdateType, opt => opt.ResolveUsing(resolver))
            //    .ForMember(feed => feed.PhotoId, opt => opt.ResolveUsing(item => item.Id.Substring(item.Id.LastIndexOf("/") + 1, item.Id.Length - item.Id.LastIndexOf("/") - 1)))
            //    .ForMember(feed => feed.Tag, opt => opt.ResolveUsing(tagResolver))
            //    .WithProfile(Profile);
            
            //Mapper.CreateMap<SyndicationFeed, Feed>()
            //    .ForMember(feed => feed.Title, opt => opt.MapFrom(feed => feed.Title.Text))
            //    .ForMember(feed => feed.Updated, expression => expression.Ignore())
            //    .ForMember(feed => feed.Entry, expression => expression.Ignore())
            //    .ForMember(feed => feed.Slug, expression => expression.Ignore())
            //    .ForMember(feed => feed.Summary, expression => expression.Ignore())
            //    .ForMember(feed => feed.Content, expression => expression.Ignore())
            //    .ForMember(feed => feed.Tags, expression => expression.Ignore())
            //    .ForMember(feed => feed.PublishDate, expression => expression.Ignore())
            //    .ForMember(feed => feed.CategoriesScheme, expression => expression.Ignore())
            //    .ForMember(feed => feed.ContentType, expression => expression.Ignore())
            //    .ForMember(feed => feed.LastUpdated, expression => expression.Ignore())
            //    .ForMember(feed => feed.Links, expression => expression.Ignore())
            //    .ForMember(feed => feed.Xml, expression => expression.Ignore())
            //    .ForMember(feed => feed.Entry, expression => expression.MapFrom(feed => Mapper.Map<IEnumerable<SyndicationItem>, IEnumerable<Entry>>(feed.Items)))
            //    .WithProfile(Profile);


            base.Configure();
        }

        public override string ProfileName
        {
            get
            {
                return Profile;
            }
        }
    }
}