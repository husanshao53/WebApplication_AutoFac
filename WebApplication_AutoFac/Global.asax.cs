using Autofac;
using Autofac.Integration.Mvc;
using AutoFac_Demo2;
using AutoFac_Demo2.IRepository;
using AutoFac_Demo2.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication_AutoFac
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            #region
            //创建autofac管理注册类的容器实例
            //var builder = new ContainerBuilder();
            //下面就需要为这个容器注册它可以管理的类型
            //builder的Register方法可以通过多种方式注册类型,之前在demo1里面也演示了好几种方式了。
            //builder.RegisterType<ProductRepository>().As<IProductRepository>();
            //使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired(); // 这样支持属性注入
            //生成具体的实例
            //var container = builder.Build();
            // 下面就是使用MVC的扩展 更改了MVC中的注入方式.
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion


            #region 自动注入
            //创建autofac管理注册类的容器实例
            var builder = new ContainerBuilder();
            Assembly[] assemblies = Directory.GetFiles(AppDomain.CurrentDomain.RelativeSearchPath, "*.dll").Select(Assembly.LoadFrom).ToArray();
            //注册所有实现了 IDependency 接口的类型
            Type baseType = typeof(IDependency);
            builder.RegisterAssemblyTypes(assemblies)
                   .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                   .AsSelf().AsImplementedInterfaces()
                   .PropertiesAutowired().InstancePerLifetimeScope();

            //注册MVC类型
            builder.RegisterControllers(assemblies).PropertiesAutowired();
            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


    }
}
