using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginDetails.Models;

namespace LoginDetails.Controllers
{
    public class LoginSignUpController : Controller
    {
        // GET: LoginSignUp
        UserDBContext context = new UserDBContext();
        public ActionResult OpeningPage()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(User log)
        {
            var data = context.Users.Where(model => model.UserName == log.UserName && model.Password == log.Password).FirstOrDefault();
            if (data != null)
            {
                Session["userId"] = log.Id.ToString();
                Session["username"] = log.UserName.ToString();
                TempData["loginmessage"] = "<script>alert('Login Successfull!')</script>";
                return RedirectToAction("Index", "Logout");
            }
            else
            {
                ViewData["errormessage"] = "<script>alert('Username or Password is incorrect!!')</script>";
                return View("Login");
            }

        }

        public ActionResult SignUP()
        {
            return View("signUP");
        }
        [HttpPost]
        public ActionResult SignUP(User l)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(l);
                int status = context.SaveChanges();
                if (status > 0)
                {

                    ViewBag.Messages = "<script>alert('Registration done Successfully!')</script>";
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.Messages = "<script>alert('Registration Unsuccessfull!!')</script>";
            }
            return View();
        }
    }
}
