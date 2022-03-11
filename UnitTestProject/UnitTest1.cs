using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Education;
using Education.Controllers;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Test_one()
        {
            var c = new UnittestController();

            var result = c.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
