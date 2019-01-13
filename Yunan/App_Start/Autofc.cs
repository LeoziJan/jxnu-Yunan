using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using IBLL;
using System.Web.Compilation;

namespace App_Start
{
    public static class Autofc
    {
        public static IContainer container;
        public static void InitAutofc()
        {
            ContainerBuilder builder = new ContainerBuilder();
            
            var baseType = typeof(IDependency);
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
            var AllServices = assemblys
                .SelectMany(s => s.GetTypes())
                .Where(p => baseType.IsAssignableFrom(p) && p != baseType);

            builder.RegisterControllers(assemblys.ToArray());

            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerLifetimeScope();         
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //例子1 失败
            //var BLL = Assembly.Load("BLL");
            //builder.RegisterAssemblyTypes(BLL).Where(a => a.Name.EndsWith("Manage")).AsImplementedInterfaces();
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //例子2 失败
            //----------------------------------------------------------------------------------------
            //构造方法进行自动注入使用方式(官方推荐)
            //----------------------------------------------------------------------------------------
            //方式一
            //builder.RegisterType<ShowDao>();
            //builder.RegisterType<HomeController>();
            //方式二
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Manage"));
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Controller")).InstancePerLifetimeScope();
            //方式三
            // builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());

            //----------------------------------------------------------------------------------------
            //                      属性自动注入使用方式
            //----------------------------------------------------------------------------------------
            //方式一
            //builder.Register(c => new HomeController { showDao = c.Resolve<ShowDao>() });
            //方式二
            //builder.RegisterType<ShowDao>();
            // builder.RegisterType<HomeController>().PropertiesAutowired();
            //方式三
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Dao")).SingleInstance();
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Controller")).InstancePerLifetimeScope().PropertiesAutowired();
            //----------------------------------------------------------------------------------------
            //container = builder.Build();            
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
