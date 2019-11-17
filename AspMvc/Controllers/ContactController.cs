using AspMvc.Infrastructrure;
using AspMvc.Models.Forms;
using AspMvc.Models.Locator;
using AspMvc.Models.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvc.Controllers
{
    [AuthRequired]
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View(ServicesLocator.Instance.ContactService.Get(SessionManager.User.Id).Select(c => c.ToDetail())); ;
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            DetailContactForm detailContactForm = ServicesLocator.Instance.ContactService.Get(SessionManager.User.Id, id)?.ToDetail();

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
                if (ModelState.IsValid)
                {
                    ServicesLocator.Instance.ContactService.Insert(SessionManager.User.Id, form.ToContact());
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
            return View(ServicesLocator.Instance.ContactService.Get(SessionManager.User.Id, id).ToUpdate());
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
                    ServicesLocator.Instance.ContactService.Update(SessionManager.User.Id, id, form.ToContact());
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
            DetailContactForm detailContactForm = ServicesLocator.Instance.ContactService.Get(SessionManager.User.Id, id)?.ToDetail();

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
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ServicesLocator.Instance.ContactService.Delete(SessionManager.User.Id, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
