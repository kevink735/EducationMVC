using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education.Dataacess;
using Education.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;


namespace Education.Controllers
{
    public class StudentController : Controller
    {
        EducationContext studentcontext = new EducationContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

       [HttpGet]
        public ActionResult GetAllstudents()
        {
            Dataaces ds = new Dataaces();
            List<student> student = ds.GetAllstudent();
            return View(student);

        }
      
    


     [HttpGet]
        public ActionResult searchstudent()
        {
         //   Dataaces ds = new Dataaces();
         //   List<student> student = ds.GetNostudent();
            return View();

   
        }



     public ActionResult Search(FormCollection frm)
       {

           if (frm.Count != 0 )
           {
               string searchBystr = frm["searchBy"].ToString();
               string searchtxt = frm["searchText"];
               Dataaces ds = new Dataaces();
               List<StudentDTO> student = ds.GetStudent(searchBystr, searchtxt);
               return View("searchstudent", student);
           }
           else
           {
               return View();
           }
       }


     [HttpGet]
     public ActionResult StudentDetails(int id)
     {

         Dataaces ds = new Dataaces();
         student student = ds.GetStudentDetails(id).FirstOrDefault();
         return View(student);

     }



        [HttpGet]
        public ActionResult student()
        {
            Dataaces ds = new Dataaces();
            ViewBag.country = ds.FillCountry();
            return View();

        }

        [HttpPost]
        public ActionResult student(student student)
        {

            Dataaces ds = new Dataaces();
            if (ModelState.IsValid)
            {

                int i = ds.AddStudent(student);
                if (i == 1)
                { ModelState.Clear();
                  TempData["Message"] = "Student Registration Complete!";
                }

            }
            else
            {

                ViewBag.country = ds.FillCountry();
                return View();
            }

            ViewBag.country = ds.FillCountry();

           
            return View();

        }



        public ActionResult MultipleButtonDemo()
        {
            return View();

        }

        public ActionResult First()
        {
            Dataaces ds = new Dataaces();
            List<student> student = ds.GetAllstudent();
            return View("GetAllstudents", student);



        }

        public ActionResult Second()
        {
            return View("Index");

        }

         [HttpGet]
        public ActionResult courseAdd()
        {
            return View();
       }


        public ActionResult SaveCourse(string coursename)
        {

            int status = 0;
            Dataaces ds = new Dataaces();
            status = ds.addcourse(coursename);
            return Json(status, JsonRequestBehavior.AllowGet);

        }

    }
}