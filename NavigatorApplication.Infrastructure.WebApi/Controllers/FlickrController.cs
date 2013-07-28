using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NavigatorApplication.Infrastructure.WebApi.Controllers
{
    public class FlickrController : Controller
    {
        //
        // GET: /Flickr/

        public ActionResult Index()
        {
            return View();
        }

    }
}
