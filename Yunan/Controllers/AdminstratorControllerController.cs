using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bll;
using Yunan.Attributes;
using Model;

namespace Yunan.Controllers
{
    public class AdminstratorControllerController : Controller
    {
        AdminsManage adminsmanage = new AdminsManage();
        YunanEntities db = new YunanEntities();

        // GET: Administrator
        [IsLoginAttributes.IsLogIn(IsCheck = true)]
        //[Authorize(Roles ="admin",Users ="鄢金卫")]
        public ActionResult Index()
        {
            var admin = adminsmanage.GetAdminByName(Session["AdminName"].ToString()).FirstOrDefault();
            if (admin.AdminName == null)
            {
                return Content("<script>alert('对不起，您无权访问该页面！');window.open('" + Url.Action("Index", "Home") + "', '_self')</script>");
            }
            else
            {
                return View(admin);
            }
        }
    }
}