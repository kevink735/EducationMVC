using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education.Dataacess;
using Education.Models;


namespace Education.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            Dataaces ds = new Dataaces();
            List<student> student = ds.GetAllstudent();
            return View(student);
        }


        public ActionResult ShowReport()
        {

            ReportDocument rd = new ReportDocument();
            StudentDTO std = new StudentDTO();
            Dataaces ds = new Dataaces();
            var c = ds.GetAllstudent();

            string s = (Path.Combine(Server.MapPath("~/Reports/StudentReport.rpt")));
            if (!string.IsNullOrEmpty(s))
            {
                rd.Load(Path.Combine(Server.MapPath("~/Reports/studentreport.rpt")));


            }
            else
            {


            }

            rd.SetDataSource(c.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream str = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            str.Seek(0, SeekOrigin.Begin);
            string SavedFilename = string.Format("studentreport.pdf", DateTime.Now);

            return File(str, "application/pdf", SavedFilename);


        }


        public ActionResult ShowReportById()
        {
            int id = 5;
            ReportDocument rd = new ReportDocument();
            student std = new student();
            Dataaces ds = new Dataaces();
            var c = ds.GetStudentDetails(id).ToList();
            string s = (Path.Combine(Server.MapPath("~/Reports/rptstudentreport.rpt")));
            if (!string.IsNullOrEmpty(s))
            {
                rd.Load(Path.Combine(Server.MapPath("~/Reports/rptstudentreport.rpt")));


            }
            else
            {


            }

            rd.SetDataSource(c.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream str = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            str.Seek(0, SeekOrigin.Begin);
            string SavedFilename = string.Format("studentreportone.pdf", DateTime.Now);

            return File(str, "application/pdf", SavedFilename);


        }

       
    }
}