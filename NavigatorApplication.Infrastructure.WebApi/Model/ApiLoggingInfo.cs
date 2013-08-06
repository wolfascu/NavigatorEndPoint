using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace NavigatorApplication.Infrastructure.WebApi.Model
{
    public class ApiLoggingInfo
    {
        public string HttpMethod { get; set; }
        public string UriAccessed { get; set; }
        public string IpAddress { get; set; }
        public string BodyContent { get; set; }
        public string Headers { get; set; }
    }
}