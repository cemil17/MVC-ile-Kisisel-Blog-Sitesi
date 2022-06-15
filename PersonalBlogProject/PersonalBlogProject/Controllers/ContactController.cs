using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace PersonalBlogProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator validations = new ContactValidator();
        Context context = new Context();
        int page = 1;

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(Contact c) // Contact Add 
        {
            ValidationResult results = validations.Validate(c);
            if (results.IsValid)
            {
                c.ContactStatus = true;
                cm.TAdd(c);
                return RedirectToAction("SendMessage");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
          
        }
        public PartialViewResult FixedAreaToMessage()
        {

            var dataInTheTrash = context.Contacts.Where(x => x.ContactStatus == false).ToList().Count();
            ViewBag.trash = dataInTheTrash;

            var commingMessage = context.Contacts.Where(x => x.ContactStatus == true).ToList().Count();
            ViewBag.message = commingMessage;


            return PartialView();
        }
        public ActionResult SendBox()
        {
            var sendboxList = cm.GetStatusActive().ToPagedList(page, 10);

            var commingMessage = context.Contacts.Where(x => x.ContactStatus == true).ToList().Count();
            ViewBag.message = commingMessage;

            return View(sendboxList);
        }
        public ActionResult TrashBox()
        {
            var trashBox = cm.GetStatusPassive().ToPagedList(page, 10);

            var dataInTheTrash = context.Contacts.Where(x => x.ContactStatus == false).ToList().Count();
            ViewBag.trash = dataInTheTrash;

            return View(trashBox);
        }
        public ActionResult PassiveContact(int id)
        {
            cm.ContactToFalse(id);
            return RedirectToAction("SendBox");
        }
        public ActionResult MessageDetails(int id)
        {
            Contact contact = cm.GetByID(id);
            return View(contact);
        }
        public ActionResult TrashMessageDetails(int id)
        {
            Contact contact = cm.GetByID(id);
            return View(contact);
        }
    }
}