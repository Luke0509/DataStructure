using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructure.Controllers
{
    public class QueueController : Controller
    {
        public static Queue<string> myQueue= new Queue<string>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addOne()
        {
            return View("Index");
        }
        public ActionResult hugeList()
        {
            return View("Index");
        }
        public ActionResult display()
        {
            return View("Index");
        }
        public ActionResult delete()
        {
            return View("Index");
        }
        public ActionResult clear()
        {
            return View("Index");
        }
        public ActionResult search()
        {
            return View("Index");
        }
        public ActionResult goToMain()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}