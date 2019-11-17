using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspMvcCore.Infrastructure;
using AspMvcCore.Models.Forms;
using AspMvcCore.Models.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Repositories;
using ToolBox.Connections.Database;

namespace AspMvcCore.Controllers
{
    [AuthRequired]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository<Contact> _repository;

        public ContactController(IContactRepository<Contact> repository, ISessionManager sessionManager) : base(sessionManager)
        {
            _repository = repository;
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View(_repository.Get(SessionManager.User.Id).Select(c => c.ToDetail())); ;
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            DetailContactForm detailContactForm = _repository.Get(SessionManager.User.Id, id)?.ToDetail();

            if (detailContactForm is null)
            {
                ViewBag.Error("Le contact n'existe pas");
                return RedirectToAction("Index");
            }

            return View(detailContactForm);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddContactForm form)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _repository.Insert(SessionManager.User.Id, form.ToContact());
                    return RedirectToAction(nameof(Index));
                }

                return View(form);
            }
            catch (Exception ex)
            {
#if DEBUG
                ViewBag.Error = ex.Message;
#else
                ViewBag.Error = "Une erreur est survenue durant l'insertion veuillez contacter l'administrateur du site";
#endif
                return View(form);
            }            
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.Get(SessionManager.User.Id, id).ToUpdate());
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdateContactForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(SessionManager.User.Id, id, form.ToContact());
                    return RedirectToAction(nameof(Index));
                }

                return View(form);
            }
            catch (Exception ex)
            {
#if DEBUG
                ViewBag.Error = ex.Message;
#else
                ViewBag.Error = "Une erreur est survenue durant la mise à jour veuillez contacter l'administrateur du site";
#endif
                return View(form);
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            DetailContactForm detailContactForm = _repository.Get(SessionManager.User.Id, id)?.ToDetail();

            if (detailContactForm is null)
            {
                ViewBag.Error("Le contact n'existe pas");
                return RedirectToAction("Index");
            }

            return View(detailContactForm);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _repository.Delete(SessionManager.User.Id, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}