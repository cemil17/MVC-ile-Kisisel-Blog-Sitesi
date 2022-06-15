using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList.Mvc;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlogProject.Controllers
{

    public class MailSubscribeController : Controller
    {
        // GET: MailSubscribe
        SubscribeMailManager sm = new SubscribeMailManager(new EFSubscribeMailDal());
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            sm.TAdd(p);
            return PartialView();
        }
        public ActionResult ListMail(int page = 1)
        {
            var subscribeMail = sm.GetSubscribeMails().ToPagedList(page, 10);
            return View(subscribeMail);
        }
    }
}