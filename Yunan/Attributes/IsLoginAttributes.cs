using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yunan.Attributes
{
    public class IsLoginAttributes
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
        public sealed class IsLogInAttribute : ActionFilterAttribute
        {
            public bool IsCheck { get; set; }//表示是否检查登录
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);

                if (IsCheck)
                {

                    if (filterContext.HttpContext.Session["UserName"] == null && filterContext.HttpContext.Session["AdminName"] == null)
                    {
                        filterContext.HttpContext.Response.Redirect("/Home/Login");
                    }
                }
            }
        }
    }
}