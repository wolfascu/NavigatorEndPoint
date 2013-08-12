namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Constants
{
    using System;
    using System.Configuration;

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

        public static string LogCategory
        {
            get
            {
                return ConfigurationManager.AppSettings["LogCategory"];
            }
        }
    }
}