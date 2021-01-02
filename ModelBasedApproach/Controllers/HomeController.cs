using ModelBasedApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
 
namespace ModelBasedApproach.Controllers
{
   
    public class HomeController : Controller
    {
        // GET: Home
        DoctorModelContainer db = new DoctorModelContainer();
        redchilliEntities db1 = new redchilliEntities();
        public ActionResult HtmlHelperExample()
        {
            Doctor obj = new Models.Doctor();
            obj.DoctorName = "Vidhi";

            ViewBag.Doctors = new SelectList(db.Doctors.ToList(), "DoctorId", "DoctorName",3);
            return View(obj);
        }

        public ActionResult ValidationExample()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ValidationExample(RegistrationForm reg)
        {
            if (ModelState.IsValid)
            {
                return Redirect("~/Home/ValidationExample");
            }
            else
            {
                return View(reg);
            }
           
        }



        public ActionResult Login() {

            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var userdetails = db1.Users.Where(s => s.UserName == user.UserName && s.Password == user.Password).SingleOrDefault();
           if (userdetails != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);

                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
        }
        [Authorize]
        public ActionResult Index()
        {

            return View();
        }
     
        [HttpGet]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}