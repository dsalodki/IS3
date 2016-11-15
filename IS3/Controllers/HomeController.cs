using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}