using System.Web;
using System.Web.Mvc;
using Yunan.Model;

namespace Yunan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new MyAuthorizeAttribute());
        }
    }
}
