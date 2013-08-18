namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Tracing.Model
{
    public class ApiLoggingInfo
    {
        public string HttpMethod { get; set; }

        public string UriAccessed { get; set; }
        
        public string IpAddress { get; set; }
        
        public string BodyContent { get; set; }
        
        public string Headers { get; set; }

        public string ContentType { get; set; }
    }
}