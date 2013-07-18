using System.Net.Http;

namespace NavigatorApplication.Infrastructure.WebApi.Extensions
{
    public interface IResponseEnricher
    {
        bool CanEnrich(HttpResponseMessage response);
        HttpResponseMessage Enrich(HttpResponseMessage response);
    }
}
