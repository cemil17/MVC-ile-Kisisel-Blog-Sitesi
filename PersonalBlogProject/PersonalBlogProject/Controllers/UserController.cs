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
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager userProfile = new UserProfileManager();
        BlogManager bm = new BlogManager(new EFBlogDal());
        BlogValidator validations = new BlogValidator();

        Context c = new Context();
        public ActionResult Index(string mail)
        {
            mail = (string)Session["Mail"];
            var userInfoList = userProfile.GetAuthorByMail(mail);
            return View(userInfoList);
        }


        public PartialViewResult AuthorInfo()
        {
            return PartialView();
        }

        public PartialViewResult PartialUserInfo(string mail)
        {
            mail = (string)Session["Mail"];
            var userInfoList = userProfile.GetAuthorByMail(mail);
            return PartialView(userInfoList);
        }

        public ActionResult UserInfoUpdate(Author a)
        {
            userProfile.AuthorUpdate(a);
            return RedirectToAction("Index");
        }

     
        public ActionResult BlogList(string mail)
        {
            mail = (string)Session["Mail"];
            int id = c.Authors.Where(x => x.Mail == mail).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthorTrue(id);
            return View(blogs);
        }
        public ActionResult RemoveBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("BlogList");
        }


        [HttpGet]
        public ActionResult UserBlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in c.Categories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.category = categoryValues;
            return View();
        }
        [HttpPost]
        public ActionResult UserBlogAdd(Blog b, string mail)
        {
            mail = (string)Session["Mail"];
            int id = c.Authors.Where(x => x.Mail == mail).Select(y => y.AuthorID).FirstOrDefault();
            b.AuthorID = id;
            b.BlogStatus = true;
            bm.TAdd(b);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Context c = new Context();
            List<SelectListItem> categoryValues = (from x in c.Categories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.category = categoryValues;

            Blog blog = bm.GetByID(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog b, string mail)
        {
            ValidationResult results = validations.Validate(b);
            if (results.IsValid)
            {
                mail = (string)Session["Mail"];
                int id = c.Authors.Where(x => x.Mail == mail).Select(y => y.AuthorID).FirstOrDefault();
                b.AuthorID = id;
                b.BlogStatus = true;
                bm.TUpdate(b);
                return RedirectToAction("BlogList");
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