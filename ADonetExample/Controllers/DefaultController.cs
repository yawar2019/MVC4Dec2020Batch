using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADonetExample.Models;
namespace ADonetExample.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            return View(db.getEmployees());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpName = frm["EmpName"];
            emp.EmpSalary =Convert.ToInt32(frm["EmpSalary"]);
            int i = db.saveEmployee(emp);

            return View();
        }
    }
}