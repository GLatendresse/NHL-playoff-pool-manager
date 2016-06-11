using System.Web;
using System.Web.Mvc;

namespace NHL_Playoff_Pool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
