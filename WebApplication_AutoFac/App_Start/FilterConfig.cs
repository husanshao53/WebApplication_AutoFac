﻿using System.Web;
using System.Web.Mvc;

namespace WebApplication_AutoFac
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
