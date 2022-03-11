using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Controllers
{
    public class UnittestController : Controller
    {
        // GET: Unittest
        public ActionResult Index()
        {
            return View("Test");
        }


        public int Addnum(int i, int j)
        {
            return i + j;

        }
    }
}