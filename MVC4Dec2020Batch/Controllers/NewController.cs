﻿using MVC4Dec2020Batch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4Dec2020Batch.Controllers
{
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Index()
        {
            return View();
        }

        public string getName() {
            return "Chaitaniya";
        }
        public string setId(string id )
        {
           
            return "Chaitaniya Employee Id "+id +" Company Name is "+ CompanyName();
        }
     
        public string CompanyName() {
            return "BrandService";
        }

       
        public string AddressDetail()
        {
            return "Address1:" + Request.QueryString["Address1"] + " Address2:" + Request.QueryString["Address2"];
        }

        public ViewResult getmeView()
        {

            return View("~/Views/Default/Second.cshtml");//new/getmeView==>second.cshtml
        }

        public ViewResult getmeData() {

            ViewBag.Name = "Krishna";
           

            return View("index");
        }
        public ViewResult getmeData2()
        {
            Student st = new Models.Student();
            st.studId = 1;
            st.StudentName = "Krishna";
            st.Course ="MVC";
            ViewBag.Info = st;
            return View();
        }
        public ViewResult getmeData3()
        {
            Student st = new Models.Student();
            st.studId = 1;
            st.StudentName = "Krishna";
            st.Course = "MVC";
            //object model = st;
            return View(st);
        }

        public ViewResult getmeData4()
        {
            List<Student> listobj = new List<Student>();
             

            Student st = new Models.Student();
            st.studId = 1;
            st.StudentName = "Krishna";
            st.Course = "MVC";

            Student st1 = new Models.Student();
            st1.studId = 2;
            st1.StudentName = "Sree";
            st1.Course = "Angular";


            Student st2 = new Models.Student();
            st2.studId =3;
            st2.StudentName = "Vidhi";
            st2.Course = "Phyton";

            listobj.Add(st);
            listobj.Add(st1);
            listobj.Add(st2);

            //object model = st;
            return View(listobj);
        }

        public ViewResult getmeData5(int id)
        {
            List<Student> listobj = new List<Student>();

            Student st = new Models.Student();
            st.studId = 1;
            st.StudentName = "Krishna";
            st.Course = "MVC";

            Student st1 = new Models.Student();
            st1.studId = 2;
            st1.StudentName = "Sree";
            st1.Course = "Angular";


            Student st2 = new Models.Student();
            st2.studId = 3;
            st2.StudentName = "Vidhi";
            st2.Course = "Phyton";

            listobj.Add(st);
            listobj.Add(st1);
            listobj.Add(st2);
            //--------------------------------
            List<Faculty> listfobj = new List<Faculty>();

            Faculty fobj = new Faculty();
            fobj.FacultyId = 1211;
            fobj.Name = "Rahul";

            Faculty fobj1 = new Faculty();
            fobj1.FacultyId = 1212;
            fobj1.Name = "james";

            listfobj.Add(fobj);
            listfobj.Add(fobj1);

            //  --------------------------------------------------
            StudentFaculty sft = new StudentFaculty();
            sft.st = listobj;
            sft.ft = listfobj;

            return View(sft);
        }

        public RedirectResult GoToYAhoo() {

            return Redirect("http://www.yahoo.com");
        }
        public RedirectResult GoToLocalMethod(int ? id)
        {

            return Redirect("~/new/getmeData5?id=1");
        }

        public RedirectToRouteResult gotoRoute()
        {
            return RedirectToRoute("xyz");

        }

        public RedirectToRouteResult gotoRoute2()
        {
            return RedirectToAction("GoToLocalMethod","new",new { id=1});

        }

        public JsonResult getjsondata()
        {
            List<Student> listobj = new List<Student>();

            Student st = new Models.Student();
            st.studId = 1;
            st.StudentName = "Krishna";
            st.Course = "MVC";

            Student st1 = new Models.Student();
            st1.studId = 2;
            st1.StudentName = "Sree";
            st1.Course = "Angular";


            Student st2 = new Models.Student();
            st2.studId = 3;
            st2.StudentName = "Vidhi";
            st2.Course = "Phyton";

            listobj.Add(st);
            listobj.Add(st1);
            listobj.Add(st2);
            return Json(listobj,JsonRequestBehavior.AllowGet);

        }

        public FileResult GetFile()
        {
            return File("~/Web.config", "text");
        }
        public FileResult GetFile1()
        {
            return File("~/Web.config", "application/xml");
        }

        public FileResult GetFile2()
        {
            return File("~/Web.config", "application/xml", "Web.config");
        }
        public ContentResult GetMyContent(int? id)
        {
            if (id == 1) {
                return Content("hello World");
            }
            else if (id == 2) {
                return Content("<script>alert('hello World')</script>");
            }
            else {
                return Content("<p style=color:red>hello world</p>");
            }
           
        }

        public ActionResult GetPartialView()
        {

            Faculty fobj = new Faculty();
            fobj.FacultyId = 1211;
            fobj.Name = "Rahul";


            return View(fobj);
        }
    }
}