using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using NavigatorApplication.Infrastructure.WebApi.Model;

namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Handler
{
    public class LogHandler : DelegatingHandler
    {
        private static readonly log4net.ILog _Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            
            //var a = request.Content.ToString();
            var context = new HttpContextWrapper(HttpContext.Current);
            var info = ExtractLoggingInfoFromRequest(request, context);
            log4net.ThreadContext.Properties["HttpMethod"] = info.HttpMethod;
            log4net.ThreadContext.Properties["Headers"] = info.Headers;
            log4net.ThreadContext.Properties["UriAccessed"] = info.UriAccessed;
            log4net.ThreadContext.Properties["IpAddress"] = info.IpAddress;
            log4net.ThreadContext.Properties["BodyContent"] = info.BodyContent;

            return base.SendAsync(request, cancellationToken);
        }

        private ApiLoggingInfo ExtractLoggingInfoFromRequest(HttpRequestMessage request, HttpContextWrapper context)
        {
            var info = new ApiLoggingInfo();
            info.HttpMethod = request.Method.Method;
            info.UriAccessed = request.RequestUri.AbsoluteUri;
            info.IpAddress = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "0.0.0.0";
            
            HttpRequestBase req = context.Request;
            var inputStream = req.InputStream;
            inputStream.Position = 0;
            using (var reader = new StreamReader(inputStream))
            {
                info.Headers = request.Headers.ToString();
                info.BodyContent = reader.ReadToEnd();
            }
            
            return info;
        }
    }
}