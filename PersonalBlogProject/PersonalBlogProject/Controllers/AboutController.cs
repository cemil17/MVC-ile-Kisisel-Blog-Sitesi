using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlogProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EFAboutDal());
        ProjectManager pm = new ProjectManager(new EFProjectDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            var aboutText = am.GetList();
            return View(aboutText);
        }
        [AllowAnonymous]
        public PartialViewResult ProjectPage()
        {
            var projectList = pm.GetList();
            return PartialView(projectList);
        }

        [AllowAnonymous]

        public PartialViewResult Footer()
        {
            var aboutFooter = am.GetList();
            return PartialView(aboutFooter);
        }
        [AllowAnonymous]

        public PartialViewResult MeetTheTeam()
        {
            AuthorManager manager = new AuthorManager(new EFAuthorDal());
            var getAuthor = manager.StatusActive();
            return PartialView(getAuthor);
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutList = am.GetList();
            return View(aboutList);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            am.TUpdate(p);
            return RedirectToAction("UpdateAboutList");
        }

    }
}