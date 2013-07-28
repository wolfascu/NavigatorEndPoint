using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NavigatorApplication.Common.Helpers;
using NavigatorApplication.Service.DTO.AtomPub;
using NavigatorApplication.Infrastructure.WebApi.Model;
using Raven.Client;
using Raven.Client.Document;

namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Fomatters
{
    public class AtomPubMediaFormatter : BufferedMediaTypeFormatter
    {
        private const string AtomMediaType = "application/atom+xml";

        public AtomPubMediaFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(AtomMediaType));
            this.AddQueryStringMapping("format", "atom", AtomMediaType);           
        }

        public override bool CanReadType(Type type)
        {
            return typeof (Feed) == type;
        }

        public override bool CanWriteType(Type type)
        {
            return /*type.Implements<IPublication>() || type.Implements<IPublicationFeed>();*/ true;
        }

        public override object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            Ensure.Argument.NotNull(type, "type");
            Ensure.Argument.NotNull(readStream, "readStream");
            
            HttpContentHeaders contentHeaders = content == null ? null : content.Headers;

            // If content length is 0 then return default value for this type
            if (contentHeaders != null && contentHeaders.ContentLength == 0)
            {
                return GetDefaultValueForType(type);
            }

            try
            {
                using (readStream)
                {
                    using (var reader = XmlReader.Create(readStream))
                    {
                        var formatter = new Atom10FeedFormatter();
                        formatter.ReadFrom(reader);                                                

                        readStream.Seek(0, SeekOrigin.Begin);
                        var streamReader = new StreamReader(readStream);
                        var text = streamReader.ReadToEnd();
                        //File.WriteAllText(@"E:\" + formatter.Feed.Id.Replace(":", "") + ".xml", text);

                        var obj = AutoMapper.Mapper.Map<SyndicationFeed, Feed>(formatter.Feed);   
                        if(obj != null)
                        {
                            obj.Xml = text;
                        }
                        return obj;                       
                    }
                }
            }
            catch (Exception e)
            {
                if (formatterLogger == null)
                {
                    throw;
                }
                formatterLogger.LogError(String.Empty, e);
                return GetDefaultValueForType(type);
            }
        }       
    }
}
