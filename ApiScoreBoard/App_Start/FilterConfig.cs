using ApiScoreBoard.Helpers.Filters;
using System.Web;
using System.Web.Mvc;

namespace ApiScoreBoard
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
