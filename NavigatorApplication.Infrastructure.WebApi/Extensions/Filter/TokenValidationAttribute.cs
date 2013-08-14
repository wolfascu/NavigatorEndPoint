namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Filter
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters; 

    public class TokenValidationAttribute : ActionFilterAttribute
    {
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
                //This needs to be injected using DI
                
                //ApiKeyRepository apiKeyRepository = new ApiKeyRepository();
                //apiKeyRepository.GetApiKey(token);

                //AuthorizedUserRepository.GetUsers().First(x => x.Name == RSAClass.Decrypt(token));
                //base.OnActionExecuting(actionContext);
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Unauthorized User")
                };
                
                return;
            }



        }
    }
}