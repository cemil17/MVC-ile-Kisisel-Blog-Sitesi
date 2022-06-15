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

namespace PersonalBlogProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        BlogManager bm = new BlogManager(new EFBlogDal());
        Context c = new Context();
        //public ActionResult Index()
        //{
        //    var categoryValues = cm.CategoryTrueList();
        //    return View(categoryValues);
        //}
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = cm.CategoryTrueList();        
            return PartialView(categoryValues);
        }
        public ActionResult AdminCategoryList()
        {
            var categoryValues = cm.CategoryTrueList();
            
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddToCategories()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddToCategories(Category p)
        {
            CategoryValidator validations = new CategoryValidator();

            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                cm.ICategoryAdd(p);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteToCategory(int id)
        {
            cm.CategoryDelete(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult TrueToCategory(int id)
        {
            cm.CategoryUpdateToTrue(id);
            return RedirectToAction("AdminCategoryList");
        }
        [Authorize(Roles = "A")]
        public ActionResult DeleteCategoryList()
        {
            var deleteList = cm.CategoryFalseList();
            return View(deleteList);
        }
        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            Category category = cm.GetByID(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category p)
        {
            CategoryValidator validations = new CategoryValidator();

            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                cm.ICategoryUpdate(p);
                return RedirectToAction("AdminCategoryList");
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
    }
}