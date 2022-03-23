using System.Web;
using System.Web.Mvc;

namespace DuzMvc
{
    public class FilterConfig    // arama için kullanacağım filtreleri barındıran alan
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) 
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
