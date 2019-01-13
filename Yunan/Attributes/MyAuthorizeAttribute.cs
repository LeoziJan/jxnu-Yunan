using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Routing;

namespace Yunan.Model
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            if (HttpContext.Current.Session["UserName"] == null)
            {

                return false;
            }
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string path = filterContext.HttpContext.Request.Path;
            var routeValue = new RouteValueDictionary
            {
                {"Controller","Home" },
                {"Action","Login" },
                {"ReturnUrl",path }
            };
            filterContext.Result =new RedirectToRouteResult(routeValue);
        }
    }
}