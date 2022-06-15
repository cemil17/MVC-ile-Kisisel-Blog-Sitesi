using DataAccessLayer.Concrete;
using PersonalBlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlogProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Chart1()
        {
            return View();
        }
        public ActionResult Chart2()
        {
            return View();
        }
        public ActionResult Chart3()
        {
            return View();
        }
        public ActionResult Chart4()
        {
            return View();
        }
        public List<Class3> CategoryList()
        {
            List<Class3> category = new List<Class3>();
            using (var c = new Context())
            {
                category = c.Categories.Select(x => new Class3
                {
                    CategoryCount = x.Blogs.Count(),
                    Category = x.CategoryName,
                }).ToList();
            }
            return category;
        }
        public ActionResult VisualizeResultCategory()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }
        public List<Class4> AuthorList()
        {
            List<Class4> authorlistBlog = new List<Class4>();
            using (var c = new Context())
            {
                authorlistBlog = c.Authors.Select(x => new Class4
                {
                    AuthorBlog = x.Blogs.Count(),
                    Author = x.Name
                }).ToList();
            }
            return authorlistBlog;
        }
        public ActionResult VisualizeResultAuthor()
        {
            return Json(AuthorList(), JsonRequestBehavior.AllowGet);
        }
        public List<Class2> BlogList()
        {
            List<Class2> list = new List<Class2>();
            using (var c = new Context())
            {
                list = c.Blogs.Select(x => new Class2
                {
                    Blog = x.BlogTitle,
                    Rating = x.BlogRating
                }).ToList();
            }
            return list;
        }
        public ActionResult VisualizeResultBlog()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<Class1> categoryList()
        {
            List<Class1> c = new List<Class1>();

            c.Add(new Class1()
            {
                Category = "Teknoloji",
                BlogCount = 5
            });

            c.Add(new Class1()
            {
                Category = "Spor",
                BlogCount = 14
            });

            c.Add(new Class1()
            {
                Category = "Yazılım",
                BlogCount = 10
            });

            return c;
        }
        public ActionResult VisualizeResult()
        {
            return Json(categoryList(), JsonRequestBehavior.AllowGet);
        }
    }
}