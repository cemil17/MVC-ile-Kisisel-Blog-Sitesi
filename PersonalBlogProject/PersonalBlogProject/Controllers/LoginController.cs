using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonalBlogProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();

        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author a)
        {
            var userInfo = c.Authors.FirstOrDefault(x => x.Mail == a.Mail && x.Password == a.Password);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Mail, false);
                Session["Mail"] = userInfo.Mail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminLogin(Admin a)
        {
            var adminInfo = c.Admins.FirstOrDefault(x => x.UserName == a.UserName && x.Password == a.Password);
            if (adminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.UserName, false);
                Session["UserName"] = adminInfo.UserName.ToString();
                return RedirectToAction("Dashboard", "Default");
            }

            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
        public ActionResult LogOutAdmin()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }
    }
}