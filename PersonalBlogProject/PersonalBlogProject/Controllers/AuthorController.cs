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
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager bm = new BlogManager(new EFBlogDal());
        AuthorManager am = new AuthorManager(new EFAuthorDal());
        AuthorValidator validations = new AuthorValidator();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetail = bm.GetBlogByID(id);
            return PartialView(authorDetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopulerPost(int id)
        {
            var blogAuthorID = bm.BlogTrueList().Where(c => c.BlogID == id).Select(x => x.AuthorID).
                FirstOrDefault();
            var authorBlog = bm.GetBlogByAuthor(blogAuthorID).OrderByDescending(x => x.BlogID).Take(3).ToList();
            return PartialView(authorBlog);
        }
        public ActionResult AuthorList()
        {
            var authorList = am.StatusActive();
            return View(authorList);
        }

        public ActionResult StatusPassiveToList()
        {
            var statusPassive = am.StatusPassive();
            return View(statusPassive);
        }

        [HttpGet]
        public ActionResult AuthorAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorAdd(Author a)
        {
            ValidationResult results = validations.Validate(a);
            if (results.IsValid)
            {
                am.TAdd(a);
                return RedirectToAction("AuthorList");
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
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = am.GetByID(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author a)
        {
            ValidationResult results = validations.Validate(a);
            if (results.IsValid)
            {
                am.TUpdate(a);
                return RedirectToAction("AuthorList","Author");
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
        public ActionResult DeleteAuthor(int id)
        {
            am.AuthorToFalse(id);
            return RedirectToAction("AuthorList");
        }
        public ActionResult ActiveAuthor(int id)
        {
            am.AuthorToTrue(id);
            return RedirectToAction("AuthorList");
        }
    }
}