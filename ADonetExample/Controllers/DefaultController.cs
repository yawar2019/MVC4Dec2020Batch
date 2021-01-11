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
        [HttpGet]
        public ActionResult Edit(int ? id)
        {
            EmployeeModel obj = db.getEmployeeByEmpId(id);

            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            int i = db.updateEmployeeByEmpId(emp);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(emp);

            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            EmployeeModel obj = db.getEmployeeByEmpId(id);

            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            int i = db.deleteEmployeeByEmpId(id);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
        }


        public ActionResult getMyService()
        {
            //ServiceReference1.WebService1SoapClient obj= new ServiceReference1.WebService1SoapClient();
            ServiceReference2.Service1Client obj = new ServiceReference2.Service1Client();
            ViewBag.Add=obj.Add(10, 30);
            return View();
        }
    }
}