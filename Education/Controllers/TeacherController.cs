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
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddTeacherInfo()
        {
            Dataaces ds = new Dataaces();
            ViewBag.country = ds.FillCountry();
            return View();

        }

        
        public JsonResult Addteacherdetails(string firstname, string lastname, string gender, string address, int country, decimal sal)
        {
            int status = 0;
            Dataaces ds = new Dataaces();
            status = ds.addteacher(firstname, lastname, gender, address, country, sal);

            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Jobs(int page = 1, int pagesize = 4)
        {
            Dataaces ds = new Dataaces();
            List<Jobs> jobtable = ds.jobs();
            PagedList<Jobs> jobtablez = new PagedList<Jobs>(jobtable, page, pagesize);
            return View(jobtablez);

        }

    }
}