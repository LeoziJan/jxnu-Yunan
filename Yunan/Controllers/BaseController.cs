using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Model;
using bll;
using System.Web.Routing;
using System.Web.SessionState;

namespace Yunan.Controllers
{
    public abstract class BaseController : Controller
    {
        private UsersManage um = new UsersManage();
        private Users user = new Users();
        public UsersManage userManage
        {
            get { return um; }
        }       
        // GET: Base
        public BaseController()
        {          
            if (System.Web.HttpContext.Current.Session["UserName"] != null)
            {
                var name = System.Web.HttpContext.Current.Session["UserName"].ToString();          
                ViewBag.UserName = System.Web.HttpContext.Current.Session["UserName"];
                user= userManage.LoadService(u => u.UserName == name).FirstOrDefault();
                ViewBag.headimg = user.UserHeadimg;
                ViewData["User"] = user;                
            }
            else
            {
                ViewBag.UserName = null;
                ViewBag.headimg = null;
            }
        }       
        //过滤器的定义也可以在这申明
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    base.OnActionExecuting(filterContext);
        //}
    }       
}