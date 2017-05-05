using System;
using System.Web;
using System.Web.Mvc;

namespace IT_Heaven
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute
            {
                ExceptionType = typeof(NullReferenceException),
                View = "InvadersError"
            });
            filters.Add(new HandleErrorAttribute());
        }
    }
}
