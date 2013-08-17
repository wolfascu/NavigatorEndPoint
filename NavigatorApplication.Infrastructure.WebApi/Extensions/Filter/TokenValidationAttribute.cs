namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Filter
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using System.Web.Http;
    using NavigatorApplication.Service.Repository;

    public class TokenValidationAttribute : ActionFilterAttribute
    {
        private readonly IApiKeyRepository _apiKeyRepository;

        public TokenValidationAttribute()
            : this(GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IApiKeyRepository)) as IApiKeyRepository)
        {

        }

        public TokenValidationAttribute(IApiKeyRepository apiApiKeyRepository)
        {
            _apiKeyRepository = apiApiKeyRepository;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string token;

            try
            {
                token = actionContext.Request.Headers.GetValues("Authorization-Token").First();
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Missing Authorization-Token")
                };
                return;
            }

            try
            {
                if (_apiKeyRepository.GetApiKey(token))
                {
                    //some code
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                    {
                        Content = new StringContent("Unauthorized User")
                    };

                    return;
                }
                base.OnActionExecuting(actionContext);
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Error encountered while attempting to process authorization token")
                };
            }
        }
    }
}