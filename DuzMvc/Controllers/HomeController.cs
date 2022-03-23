using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuzMvc.Dal;

namespace DuzMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DuzDbContext db = new DuzDbContext();
            db.Sahips.ToList();
            return View(db);

            Guid test = Guid.NewGuid();
            var a = test.ToString();
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    
        public ActionResult Deneme() // Buradan css html işlemlerine devam edicez.
        {
            
            return View();

        }
    
    }
}