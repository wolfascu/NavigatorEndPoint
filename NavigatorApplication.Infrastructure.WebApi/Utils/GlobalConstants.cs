using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NavigatorApplication.Infrastructure.WebApi.Utils
{
    public class GlobalConstants
    {
        public static bool IsPipelineLogged
        {
            get
            {
                var configSection = ConfigurationManager.AppSettings["IsPipelineLogged"];
                bool result;
                if (Boolean.TryParse(configSection, out result))
                {
                    return result;
                }
                return false;
            }
        }

        public static string LogCategory {
            get
            {
                return ConfigurationManager.AppSettings["LogCategory"];
            }
        }
    }
}