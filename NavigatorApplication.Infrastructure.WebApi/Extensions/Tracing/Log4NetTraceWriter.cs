namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Tracing
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Web;
    using System.Web.Http.Tracing;

    using NavigatorApplication.Infrastructure.WebApi.Extensions.Constants;
    using NavigatorApplication.Infrastructure.WebApi.Extensions.Tracing.Model;

    using log4net;
    using System.Threading.Tasks;

    public class Log4NetTraceWriter : ITraceWriter
    {
        public bool IsEnabled(string category, TraceLevel level)
        {
            return true;
        }

        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level == TraceLevel.Off)
                return;

            if (!string.IsNullOrWhiteSpace(GlobalConstants.LogCategory) &&
                category != GlobalConstants.LogCategory)
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


            if (GlobalConstants.IsPipelineLogged && record.Kind != TraceKind.Begin)
                return;

            if (record.Request != null)
            {
                var info = ExtractLoggingInfoFromRequest(record.Request, new HttpContextWrapper(HttpContext.Current));
                ThreadContext.Properties["HttpMethod"] = info.HttpMethod;
                ThreadContext.Properties["Headers"] = info.Headers;
                ThreadContext.Properties["UriAccessed"] = info.UriAccessed;
                ThreadContext.Properties["IpAddress"] = info.IpAddress;
                ThreadContext.Properties["BodyContent"] = info.BodyContent;
                ThreadContext.Properties["Content-Type"] = info.ContentType;

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
            var info = new ApiLoggingInfo
            {
                HttpMethod = request.Method.Method,
                UriAccessed = request.RequestUri.AbsoluteUri,
                IpAddress = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "0.0.0.0",
                ContentType = context.Request.ContentType
            };
           
            Task<string> getContentTask = request.Content.ReadAsStringAsync();

            info.BodyContent = getContentTask.Result;
            info.Headers = request.Headers.ToString();
           

            return info;
        }
    }
}