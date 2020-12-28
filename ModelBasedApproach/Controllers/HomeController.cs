using ModelBasedApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBasedApproach.Controllers
{
   
    public class HomeController : Controller
    {
        // GET: Home
        DoctorModelContainer db = new DoctorModelContainer();
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
    }
}