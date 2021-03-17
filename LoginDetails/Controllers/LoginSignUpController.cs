using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        //for user login

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
        //for user
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

        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin log)
        {
            var data = context.Admins.Where(model => model.userid == log.userid && model.password == log.password).FirstOrDefault();
            if (data != null)
            {
                Session["userId"] = log.Id.ToString();
                Session["username"] = log.userid.ToString();
                TempData["loginmessage"] = "<script>alert('Login Successfull!')</script>";
               // return RedirectToAction("Index", "Logout");
                return RedirectToAction("Index", "Adminaction");
            }
            else
            {
                ViewData["errormessage"] = "<script>alert('Username or Password is incorrect!!')</script>";
                return View();
            }

        }

        public ActionResult AdminSignup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminSignup(Admin l)
        {
            if (ModelState.IsValid)
            {
                context.Admins.Add(l);
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

        public ActionResult AtmCheckbook()
        {
            TempData["Messages"] = "<script>alert('ATM Request Registration Successfully!')</script>";
            return View();
        }

        public ActionResult UserDashboard()
        {
            return View();
        }
        public ActionResult Beneficiary()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Beneficiary(Beneficiary ben)
        {

            if (ModelState.IsValid)
            {
                context.Beneficiaries.Add(ben);
                int status = context.SaveChanges();
                if (status > 0)
                {

                    TempData["Messages"] = "<script>alert('Beneficiary added Successfully!')</script>";
                    ModelState.Clear();
                }
            }
            else
            {
                TempData["Messages"] = "<script>alert('Beneficiary not added')</script>";
            }
            return View();
            
        }

        public ActionResult ForgotPass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPass(User log)
        {
            var data = context.Users.Where(model => model.Email == log.Email && model.AccountNumber == log.AccountNumber).FirstOrDefault();
            if (data != null)
            {


                return RedirectToAction("CreatePass", "LoginSignUp");
            }
                    
                ViewData["errormessage"] = "<script>alert('Email or Account Number not Found!!')</script>";
                return View();
            
        }
        public ActionResult CreatePass(int? Id)
        {
            var data = context.Users.ToList();
            return View(data);
     
        }

        public ActionResult Kyc()
        {
            TempData["Messages"] = "<script>alert('KYC Registration Successfully!')</script>";
            return View();
        }
       
    }
}

