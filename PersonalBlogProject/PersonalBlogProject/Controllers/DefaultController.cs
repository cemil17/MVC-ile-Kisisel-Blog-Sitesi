using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlogProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        [AllowAnonymous]
        public ActionResult TagColors()
        {
            return View();
        }


        public ActionResult Dashboard()
        {
            return View();
        }

        public PartialViewResult Tags()
        {
            var maxBlog = c.Blogs.Where(x => x.BlogStatus == true).Count();
            ViewBag.blog = maxBlog;

            var maxAuthor = c.Authors.Where(x => x.AuthorStatus == true).Count();
            ViewBag.author = maxAuthor;

            var maxMessage = c.Comments.Where(x => x.CommentStatus == true).Count();
            ViewBag.message = maxMessage;

            var maxCategory = c.Categories.Where(s => s.CategoryStatus == true).Count();
            ViewBag.category = maxCategory;

            return PartialView();
        }
        public PartialViewResult Comments()
        {
            return PartialView();
        }
    }
}