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
    public class ApplicantController : Controller
    {
        // GET: Applicant
        public ActionResult Index()
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
        public ActionResult ApplyNowx(Applicant applicant, HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {

                Dataaces ds = new Dataaces();
                if (ModelState.IsValid)
                {

                    int i = ds.AddApplicant(applicant , "test" );
                    if (i == 1)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                        file.SaveAs(_path);
                        ModelState.Clear();
                        TempData["Message"] = "Job Application Complete!";
                    }

                }

                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);

                }


            }

            return View();
        }

    }
}