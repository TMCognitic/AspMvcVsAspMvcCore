using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspMvcCore.Infrastructure;
using AspMvcCore.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Repositories;
using ToolBox.Connections.Database;

namespace AspMvcCore.Controllers
{
    public class AuthController : Controller
    {
        private IAuthRepository<User> _repository;
        private ISessionManager _sessionManager;

        public AuthController(ISessionManager sessionManager, IAuthRepository<User> repository)
        {
            _repository = repository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginForm form)
        {
            if(ModelState.IsValid)
            {
                User user = _repository.Login(new User() { Email = form.Email, Passwd = form.Passwd });

                if (!(user is null))
                {
                    _sessionManager.User = user;
                    return RedirectToAction("Index", "Contact");
                }
            }

            return View(form);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                _repository.Register(new User() { LastName = form.LastName, FirstName = form.FirstName, Email = form.Email, Passwd = form.Passwd });
                return RedirectToAction("Login");
            }

            return View(form);
        }
    }
}