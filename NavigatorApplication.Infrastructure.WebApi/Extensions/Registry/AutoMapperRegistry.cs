using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Registry
{
    public class AutomapperRegistry
    {
        public static void Configure()
        {
            Mapper.Reset();
            Mapper.Initialize(x =>
            {
                x.AddProfile<FeedProfile>();
                /*x.AddProfile<EntryProfile>();*/
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}