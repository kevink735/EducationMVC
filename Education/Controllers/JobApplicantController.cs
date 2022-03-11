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
    public class JobApplicantController : Controller
    {
        // GET: JobApplicant
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult JobApplicant()
        {
            Dataaces ds = new Dataaces();
            ViewBag.country = ds.FillCountry();
            ViewBag.job = ds.Filljob();
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(int id)
        {
            Dataaces ds = new Dataaces();
            List<statetable> st = ds.Fillstate(id).ToList();
            ViewBag.staterec = st;
            return Json(st, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult JobApplicant(Applicant applicant, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0 && file.ContentLength != null)
            {

                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                file.SaveAs(_path);


                Dataaces ds = new Dataaces();
                if (ModelState.IsValid)
                {

                    int i = ds.AddApplicant(applicant, _path);

                    if (i > 0)
                    {
                        ModelState.Clear();
                        return RedirectToAction( "Confirmation", new { id = i });
                    }

                }
                else
                {
                    ViewBag.country = ds.FillCountry();
                    ViewBag.job = ds.Filljob();
                     int i = ds.AddApplicant(applicant, _path);

                     if (i > 0)
                     {
                         return RedirectToAction("Confirmation", new { id = i });
                     }
                     else
                     {
                         return View();
                     }
                }

                

            }  

            else
              {
                TempData["Message"] = "Please upload a file!";
                return View();

              }


            return View();
       

        }


        [HttpGet]
        public ActionResult Confirmation(int id)
        {

            Dataaces ds = new Dataaces();
            List<Applicant> Applicant = ds.GetApplicantDetails(id);
            return View("Confirmation", Applicant);


        }





      [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                file.SaveAs(_path);
                return PartialView("~/Views/JobApplicant/_FileUpload.cshtml");
                
            }

            else {
                return View("Thanks");
            }

        }


        /*
        [HttpPost]
        public ActionResult upload(Applicant applicant, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                file.SaveAs(_path);
                TempData["Message"] = " File Upload Complete!";
            }

            Dataaces ds = new Dataaces();
            if (ModelState.IsValid)
            {

                int i = ds.AddApplicant(applicant);
                if (i == 1)
                {
                    ModelState.Clear();
                    TempData["Message"] = " Complete!";
                }

            }
            else
            {

                ViewBag.country = ds.FillCountry();
                return View("JobApplicant");
            }

            ViewBag.country = ds.FillCountry();


            return View("JobApplicant");
        }
        */
    }
}