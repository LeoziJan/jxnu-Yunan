using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace Yunan.Controllers
{
    public class AdminManagementController : Controller
    {
        private YunanEntities db = new YunanEntities();
        // GET: AdminManagement
        public  ActionResult Index()
        {
            return View();
        }
    }
}