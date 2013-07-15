using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel.Syndication;
using System.Net;
using System.Xml;
using NavigatorApplication.Service.DTO;

namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Fomatters
{
    //public class SyndicationFeedFormatter : MediaTypeFormatter
    //{
    //    private readonly string atom = "application/atom+xml";
    //    private readonly string rss = "application/rss+xml";

    //    public SyndicationFeedFormatter()
    //    {
    //        SupportedMediaTypes.Add(new MediaTypeHeaderValue(atom));
    //        SupportedMediaTypes.Add(new MediaTypeHeaderValue(rss));
    //    }

    //    public override bool CanReadType(Type type)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool CanWriteType(Type type)
    //    {
    //        if (type == typeof(Url) || type == typeof(IEnumerable<Url>))
    //            return true;
    //        else
    //            return false;
    //    }

    //    public override Task OnWriteToStreamAsync(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, FormatterContext formatterContext, TransportContext transportContext)
    //    {
    //        return Task.Factory.StartNew(() =>
    //        {
    //            if (type == typeof(Url) || type == typeof(IEnumerable<Url>))
    //                BuildSyndicationFeed(value, stream, contentHeaders.ContentType.MediaType);
    //        });
    //    }

    //    private void BuildSyndicationFeed(object models, Stream stream, string contenttype)
    //    {
    //        List<SyndicationItem> items = new List<SyndicationItem>();
    //        var feed = new SyndicationFeed()
    //        {
    //            Title = new TextSyndicationContent("My Feed")
    //        };

    //        if (models is IEnumerable<Url>)
    //        {
    //            var enumerator = ((IEnumerable<Url>)models).GetEnumerator();
    //            while (enumerator.MoveNext())
    //            {
    //                items.Add(BuildSyndicationItem(enumerator.Current));
    //            }
    //        }
    //        else
    //        {
    //            items.Add(BuildSyndicationItem((Url)models));
    //        }

    //        feed.Items = items;

    //        using (XmlWriter writer = XmlWriter.Create(stream))
    //        {
    //            if (string.Equals(contenttype, atom))
    //            {
    //                Atom10FeedFormatter atomformatter = new Atom10FeedFormatter(feed);
    //                atomformatter.WriteTo(writer);
    //            }
    //            else
    //            {
    //                Rss20FeedFormatter rssformatter = new Rss20FeedFormatter(feed);
    //                rssformatter.WriteTo(writer);
    //            }
    //        }
    //    }

    //    private SyndicationItem BuildSyndicationItem(Url u)
    //    {
    //        var item = new SyndicationItem()
    //        {
    //            Title = new TextSyndicationContent(u.Title),
    //            BaseUri = new Uri(u.Address),
    //            LastUpdatedTime = u.CreatedAt,
    //            Content = new TextSyndicationContent(u.Description)
    //        };
    //        item.Authors.Add(new SyndicationPerson() { Name = u.CreatedBy });

    //        return item;
    //    }
    //}
}