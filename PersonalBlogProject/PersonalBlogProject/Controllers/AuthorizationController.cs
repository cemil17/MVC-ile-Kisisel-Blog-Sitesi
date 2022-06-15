using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlogProject.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EFAdminDal());
        AdminValidator validations = new AdminValidator();
        public ActionResult Index()
        {
            var adminList = adminManager.GetList();
            return View(adminList);
        }
        [HttpGet]
        public ActionResult AddToAdmin()
        {
            var adminList = adminManager.GetList();
            return View(adminList);
        }
        [HttpPost]
        public ActionResult AddToAdmin(Admin p)
        {
            adminManager.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminEdit(int id)
        {
            Admin admin = adminManager.GetByID(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult AdminEdit(Admin p)
        {
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                adminManager.TUpdate(p);
                return RedirectToAction("Index");
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
        public ActionResult AdminRemove(int id)
        {
            adminManager.AdminDelete(id);
            return RedirectToAction("Index");
        }
    }
}