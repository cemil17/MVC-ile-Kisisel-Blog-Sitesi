using BusinessLayer.Concrete;
using PagedList.Mvc;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace PersonalBlogProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager(new EFBlogDal());
        BlogValidator validations = new BlogValidator();
        CommentManager cm = new CommentManager(new EFCommentDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var blogListCategory = bm.GetBlogByCategory(id).OrderByDescending(x => x.BlogID).Where(y => y.BlogStatus == true).ToList();

            var categoryName = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = categoryName;

            var categoryDescription = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDescription = categoryDescription;

            return View(blogListCategory);
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var blogList = bm.BlogTrueList().OrderByDescending(c => c.BlogID).ToPagedList(page, 6);
            return PartialView(blogList);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPosts() // Öne çıkan postlar
        {
            // POST: 1
            var post1 = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var post1Image = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 1).Select(y => y.Image).FirstOrDefault();
            var post1Date = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var post1ID = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postTitle1 = post1;
            ViewBag.postImage1 = post1Image;
            ViewBag.postDate1 = post1Date;
            ViewBag.postID1 = post1ID;

            // POST: 2
            var post2 = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var post2Image = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 2).Select(y => y.Image).FirstOrDefault();
            var post2Date = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var post2ID = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postTitle2 = post2;
            ViewBag.postImage2 = post2Image;
            ViewBag.postDate2 = post2Date;
            ViewBag.postID2 = post2ID;

            // POST: 3
            var post3 = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 7).Select(y => y.BlogTitle).FirstOrDefault();
            var post3Image = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 7).Select(y => y.Image).FirstOrDefault();
            var post3Date = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 7).Select(y => y.BlogDate).FirstOrDefault();
            var post3ID = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 7).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postTitle3 = post3;
            ViewBag.postImage3 = post3Image;
            ViewBag.postDate3 = post3Date;
            ViewBag.postID3 = post3ID;


            // POST: 4
            var post4 = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 8).Select(y => y.BlogTitle).FirstOrDefault();
            var post4Image = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 8).Select(y => y.Image).FirstOrDefault();
            var post4Date = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 8).Select(y => y.BlogDate).FirstOrDefault();
            var post4ID = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 8).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postTitle4 = post4;
            ViewBag.postImage4 = post4Image;
            ViewBag.postDate4 = post4Date;
            ViewBag.postID4 = post4ID;

            // POST: 5
            var post5 = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 9).Select(y => y.BlogTitle).FirstOrDefault();
            var post5Image = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 9).Select(y => y.Image).FirstOrDefault();
            var post5Date = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 9).Select(y => y.BlogDate).FirstOrDefault();
            var post5ID = bm.BlogTrueList().OrderByDescending(x => x.BlogID).Where(c => c.CategoryID == 9).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postTitle5 = post5;
            ViewBag.postImage5 = post5Image;
            ViewBag.postDate5 = post5Date;
            ViewBag.postID5 = post5ID;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPosts() // Diğer öne çıkan postlar
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var blogDetailsList = bm.GetBlogByID(id);
            return PartialView(blogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsList = bm.GetBlogByID(id);
            return PartialView(blogDetailsList);
        }

        public ActionResult AdminBlogList(int page = 1)
        {
            var listOfBlog = bm.BlogTrueList().ToPagedList(page, 10);
            return View(listOfBlog);
        }
        public ActionResult AdminBlogFalseList(int page = 1)
        {
            var listOfBlog = bm.BlogFalseList().ToPagedList(page, 10);
            return View(listOfBlog);
        }

        [HttpGet]
        public ActionResult BlogAdd()
        {
            Context c = new Context();
            List<SelectListItem> categoryValues = (from x in c.Categories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            List<SelectListItem> writerValues = (from y in c.Authors.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = y.Name,
                                                     Value = y.AuthorID.ToString()
                                                 }).ToList();

            ViewBag.author = writerValues;
            ViewBag.category = categoryValues;
            return View();
        }
        [HttpPost]
        public ActionResult BlogAdd(Blog b)
        {
            ValidationResult results = validations.Validate(b);
            if (results.IsValid)
            {
                bm.TAdd(b);
                return RedirectToAction("AdminBlogList");
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

        public ActionResult RemoveBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult TrueToBlog(int id)
        {
            bm.TrueToBlog(id);
            return RedirectToAction("AdminBlogList");
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

            List<SelectListItem> writerValues = (from y in c.Authors.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = y.Name,
                                                     Value = y.AuthorID.ToString()
                                                 }).ToList();

            ViewBag.category = categoryValues;
            ViewBag.author = writerValues;

            Blog blog = bm.GetByID(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog b)
        {
            ValidationResult results = validations.Validate(b);
            if (results.IsValid)
            {
                bm.TUpdate(b);
                return RedirectToAction("AdminBlogList");
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
        public ActionResult AuthorBlogList(int id)
        {
            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }
        public ActionResult GetCommentByBlog(int id)
        {
            var commentList = cm.CommentByBlog(id);
            return View(commentList);
        }
    }
}