using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginDetails.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Login", "LoginSignUp");
            }
            else
            {
                return View();
            }

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "LoginSignUp");
        }
    }
}