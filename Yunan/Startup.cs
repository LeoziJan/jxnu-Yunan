using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Yunan.Startup))]
namespace Yunan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
