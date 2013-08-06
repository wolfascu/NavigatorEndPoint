namespace NavigatorApplication.Infrastructure.WebApi.App_Start
{
    using System.Net.Http.Formatting;
    using NavigatorApplication.Infrastructure.WebApi.Extensions.Fomatters;

    public class FormatterConfig
    {
        public static void RegisterFormatters(MediaTypeFormatterCollection formatters)
        {
            formatters.Remove(formatters.XmlFormatter);

           // formatters.Add(new AtomPubMediaFormatter());
            formatters.Add(new FlickerFeedMediaFormatter());
        }
    }
}