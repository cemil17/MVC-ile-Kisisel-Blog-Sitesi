using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using PagedList.Mvc;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlogProject.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager cm = new CommentManager(new EFCommentDal());
        CommentValidator validations = new CommentValidator();
        int page = 1;

        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentList = cm.CommentByBlog(id);
            return PartialView(commentList);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.d = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment p)
        {
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {   
                p.CommentStatus = true;
                cm.TAdd(p);
                return PartialView("CommentList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return PartialView();
            }


        }
        public ActionResult AdminCommentListTrue()
        {
            var commentList = cm.CommentByStatusTrue().ToPagedList(page, 10);
            return View(commentList);
        }
        public ActionResult AdminCommentListFalse()
        {
            var commentList = cm.CommentByStatusFalse().ToPagedList(page, 10);
            return View(commentList);
        }
        public ActionResult CommentToFalse(int id)
        {
            cm.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }
        public ActionResult CommentToTrue(int id)
        {
            cm.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }
    }
}