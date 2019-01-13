using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Dal;
using bll;

namespace Yunan.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        private UsersManage um = new UsersManage();
        public ActionResult Index()
        {
            YunanEntities db = new YunanEntities();

            //um.AddService(user);
            return View(db.Users);
        }
    }
}