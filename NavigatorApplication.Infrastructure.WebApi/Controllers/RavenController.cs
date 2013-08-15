namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using Raven.Client;
    using Raven.Client.Document;

    public abstract class RavenController : ApiController
    {
        public IDocumentStore Store
        {
            get { return LazyDocStore.Value; }
        }

        private static readonly Lazy<IDocumentStore> LazyDocStore = new Lazy<IDocumentStore>(() =>
        {
            var docStore = new DocumentStore { ConnectionStringName = "RavenDB" };
            docStore.Initialize();

            return docStore;
        });

        public IAsyncDocumentSession Session { get; set; }

        public async override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            using (Session = Store.OpenAsyncSession())
            {
                var result = await base.ExecuteAsync(controllerContext, cancellationToken);
                await Session.SaveChangesAsync();

                return result;
            }
        }
    }
}