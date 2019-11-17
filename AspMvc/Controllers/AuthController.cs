using AspMvc.Infrastructrure;
using AspMvc.Models.Forms;
using AspMvc.Models.Locator;
using Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvc.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                User user = ServicesLocator.Instance.AuthService.Login(new User() { Email = form.Email, Passwd = form.Passwd });

                if (!(user is null))
                {
                    SessionManager.User = user;
                    return RedirectToAction("Index", "Contact");
                }
            }

            return View(form);
        }

        public ActionResult Logout()
        {
            SessionManager.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                ServicesLocator.Instance.AuthService.Register(new User() { LastName = form.LastName, FirstName = form.FirstName, Email = form.Email, Passwd = form.Passwd });
                return RedirectToAction("Login");
            }

            return View(form);
        }
    }
}