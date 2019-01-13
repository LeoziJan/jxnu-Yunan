using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using App_Start;
using Common;

namespace Yunan
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;

            Autofc.InitAutofc();
            MMapper.MapperConfiguration();

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 60;
        }
    }
}
