using System.Web.Mvc;

namespace DuzMvc.Areas.adminAreaRegistration
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "adminAreaRegistration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "adminAreaRegistration_default",
                "adminAreaRegistration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            //localhost:23233/Admin/admin/Index 

        }
    }
}