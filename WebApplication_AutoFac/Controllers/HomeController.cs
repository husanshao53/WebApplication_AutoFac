using Autofac;
using AutoFac_Demo1;
using AutoFac_Demo1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_AutoFac.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            # region  builder.RegisterType<Object>().As<Iobject>()
            //var builder = new ContainerBuilder();
            //builder.RegisterType<DBManager>();
            //builder.RegisterType<SqlDAL>().As<IDAL>();
            //↑↑↑  builder.RegisterType<Object>().As<Iobject>()：注册类型及其实例   注册接口IDAL的实例SqlDAL ↑↑↑  
            //using (var container = builder.Build())
            //{
            //    var manager = container.Resolve<DBManager>();
            //    ↑↑↑ 解析某个接口的实例。 
            //    ViewBag.SqlResult = manager.Insert(" insert into test values('test1','Shanghai') ");
            //}
            #endregion


            # region   builder.RegisterType<Object>().Named<Iobject>(string name)
            //var builder = new ContainerBuilder();
            //builder.RegisterType<SqlDAL>().Named<IDAL>("sql");
            //builder.RegisterType<OracleDAL>().Named<IDAL>("oracle");
            ////为一个接口注册不同的实例。有时候难免会碰到多个类映射同一个接口，比如SqlDAL和OracleDAL都实现了IDAL接口，为了准确获取想要的类型，就必须在注册时起名字。
            //using (var container = builder.Build())
            //{
            //    //var manager = (SqlDAL)container.ResolveNamed<IDAL>("sql");
            //    var manager = container.ResolveNamed<IDAL>("oracle");
            //    ViewBag.SqlResult = manager.Insert(" insert into test values('test1','Shanghai') ");
            //}
            #endregion


            # region  builder.RegisterType<Object>().Keyed<Iobject>(Enum enum)
            //var builder = new ContainerBuilder();
            //以枚举的方式为一个接口注册不同的实例。有时候我们会将某一个接口的不同实现用枚举来区分，而不是字符串
            //builder.RegisterType<SqlDAL>().Keyed<IDAL>(DBType.Sql).InstancePerDependency();
            //    ↑↑↑ InstancePerDependency()  用于控制对象的生命周期，每次加载实例时都是新建一个实例，默认就是这种方式
            //builder.RegisterType<OracleDAL>().Keyed<IDAL>(DBType.Oracle).SingleInstance();
            //    ↑↑↑ SingleInstance() 用于控制对象的生命周期，每次加载实例时都是返回同一个实例
            //using (var container = builder.Build())
            //{
            //    var manager = container.ResolveKeyed<IDAL>(DBType.Sql);
            //      var manager = (OracleDAL)container.ResolveKeyed<IDAL>(DBType.Oracle);
            //    ViewBag.SqlResult = manager.Insert(" insert into test values('test1','Shanghai') ");
            //}
            #endregion

            return View();
        }
    }
}