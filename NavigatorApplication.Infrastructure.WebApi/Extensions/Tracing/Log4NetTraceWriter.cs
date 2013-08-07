using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Tracing;
using log4net;
using NavigatorApplication.Infrastructure.WebApi.Model;

namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Tracing
{
    public class Log4NetTraceWriter: ITraceWriter
    {
        public bool IsEnabled(string category, TraceLevel level)
        {
            return true;
        }

        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level == TraceLevel.Off)
                return;

            var record = new TraceRecord(request, category, level);
            traceAction(record);
            Log(record);
        }

        private Dictionary<TraceLevel, Action<string>> Logger
        {
            get { return s_loggingMap.Value; }
        }

        private void Log(TraceRecord record)
        {
            var message = new StringBuilder();
            var info = ExtractLoggingInfoFromRequest(record.Request, new HttpContextWrapper(HttpContext.Current));
            if (record.Request != null)
            {
                //if (record.Request.Method != null)
                //    message.Append(" ").Append(record.Request.Method.Method);
                
                //if (record.Request.RequestUri != null)
                //    message.Append(" ").Append(record.Request.RequestUri.AbsoluteUri);

                ThreadContext.Properties["HttpMethod"] = info.HttpMethod;
                ThreadContext.Properties["Headers"] = info.Headers;
                ThreadContext.Properties["UriAccessed"] = info.UriAccessed;
                ThreadContext.Properties["IpAddress"] = info.IpAddress;
                ThreadContext.Properties["BodyContent"] = info.BodyContent;
            }

            if (!string.IsNullOrWhiteSpace(record.Category))
                message.Append(" ").Append(record.Category);

            if (!string.IsNullOrWhiteSpace(record.Operator))
                message.Append(" ").Append(record.Operator).Append(" ").Append(record.Operation);

            if (!string.IsNullOrWhiteSpace(record.Message))
                message.Append(" ").Append(record.Message);

            if (record.Exception != null && !string.IsNullOrEmpty(record.Exception.GetBaseException().Message))
                message.Append(" ").AppendLine(record.Exception.GetBaseException().Message);

            Logger[record.Level](message.ToString());
        }

        private static readonly ILog s_log = LogManager.GetLogger(typeof(Log4NetTraceWriter));

        private static readonly Lazy<Dictionary<TraceLevel, Action<string>>> s_loggingMap =
            new Lazy<Dictionary<TraceLevel, Action<string>>>(() => new Dictionary<TraceLevel, Action<string>>
            {
                {TraceLevel.Info, s_log.Info},
                {TraceLevel.Debug, s_log.Debug},
                {TraceLevel.Error, s_log.Error},
                {TraceLevel.Fatal, s_log.Fatal},
                {TraceLevel.Warn, s_log.Warn}
            });

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