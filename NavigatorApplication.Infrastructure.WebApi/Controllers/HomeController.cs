using System.Web.Mvc;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


    }
}