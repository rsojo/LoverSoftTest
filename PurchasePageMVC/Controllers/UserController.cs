using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Business.DTO;
using Business.Helpers;
using Data.Entities;

namespace PurchasePageMVC.Controllers
{
    public class UserController : Controller
    {

        UserRepository userRepository = new UserRepository();

        // Register action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User User)
        {
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];
            string confirmPassword = Request.Form["Password2"];


            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match";
                return View();
            }
            if (!userRepository.UserExists(email).Error && userRepository.UserExists(email).UnitResp)
            {
                ViewBag.Error = "Email used by another User";
                return View();
            }
            var entity = new User
            {
                Email = email,
                Password = Encrypt.EncryptString(password)
            };
            var response = userRepository.Register(entity);

            if (response.Error)
            {
                ViewBag.Error = response.Msg;
                return View();
            }

            return RedirectToAction("Login");
        }


        // Login action
        [HttpPost]
        public ActionResult Login(User User)
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            var response = new BusinessResponse<User>();
            if (email != null && password != null && !email.IsEmpty() && !password.IsEmpty())
            {
                 response = userRepository.Login(email, Encrypt.EncryptString(password));

            }
            if (response.Error) {
                ViewBag.Error = response.Msg;
                return View();
            }
            Session["User"] = response.UnitResp;
            
            return RedirectToAction("Index", "Home");
        }


        // Login action
        public ActionResult Register()
        {
            return View();
        }

        // Login action
        public ActionResult Login()
        {
            return View();
        }
        // Logout action
        public ActionResult Logout()
        {

            Session["User"] = null;

            return RedirectToAction("Index", "Home");

        }
    }
}