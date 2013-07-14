using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavigatorApplication.Infrastructure.WebApi.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public class PostResponse
    {
        public string ResponseText { get; set; }
    }
}