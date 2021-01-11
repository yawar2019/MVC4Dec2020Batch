using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Filter;
namespace WebApplication2.Controllers
{

   
    public class HomeController : Controller
    {
        [MyFilter]
        public ActionResult Index()
        {
            ViewBag.player = "Ritu";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
     
        public ActionResult Contact()
        {
            try
            {
                int a = 10, b = 0;
                var result = a / b;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return View();
        }
    }
}