namespace NavigatorApplication.Infrastructure.WebApi
﻿{
﻿    using App_Start;
﻿    using Service.Registry;
﻿    using System.Web;
﻿    using System.Web.Http;
﻿    using System.Web.Mvc;
﻿    using System.Web.Routing;
﻿    using System.Web.Optimization;

﻿    public class WebApiApplication : HttpApplication
﻿    {
﻿        protected void Application_Start()
﻿        {
﻿            log4net.Config.XmlConfigurator.Configure();
﻿            AreaRegistration.RegisterAllAreas();
﻿            WebApiConfig.Register(GlobalConfiguration.Configuration);

﻿            RouteConfig.RegisterRoutes(RouteTable.Routes);
﻿            BundleConfig.RegisterBundles(BundleTable.Bundles);
﻿            FormatterConfig.RegisterFormatters(GlobalConfiguration.Configuration.Formatters);

﻿            AutomapperRegistry.Configure();

﻿            Bootstrapper.Initialise();
﻿        }
﻿    }
﻿}