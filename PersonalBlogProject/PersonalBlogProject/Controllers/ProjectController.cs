using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlogProject.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        ProjectManager pm = new ProjectManager(new EFProjectDal());

        public ActionResult ProjectList()
        {
            var list = pm.GetList();
            return View(list);
        }
    }
}