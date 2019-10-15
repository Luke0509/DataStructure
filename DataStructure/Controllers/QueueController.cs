using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DataStructure.Controllers
{
    public class QueueController : Controller
    {
        public static Queue<string> myQueue = new Queue<string>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.myData = myQueue;
            return View("Index");
        }
        public ActionResult hugeList()
        {
            myQueue.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            }
            ViewBag.myData = myQueue;
            ViewBag.Message = "2000 items added to queue!";
            return View("Index");
        }
        public ActionResult display()
        {
            ViewBag.myData = myQueue;
            return View("Display");
        }
        public ActionResult delete()
        {
            if (myQueue.Any())
            {
                myQueue.Dequeue();
            }
            else
            {
                ViewBag.Message = "There are no items to delete!";
            }
            return View("Index");
        }
        public ActionResult clear()
        {
            myQueue.Clear();
            ViewBag.myData = myQueue;
            return View("Index");
        }
        public ActionResult search()
        {
            string searchVar = "New Entry 40";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            TimeSpan ts;
            sw.Start();
            Boolean bFound = false;
            if (myQueue.Count > 0)
            {
                for (int iCount = 0; iCount < myQueue.Count(); iCount++)
                {
                    if (myQueue.ElementAt(iCount) == searchVar)
                    {
                        sw.Stop();
                        ts = sw.Elapsed;
                        ViewBag.Message = ts + " to find the item";
                        bFound = true;
                        iCount = myQueue.Count();
                    }
                }
                if (bFound == false)
                {
                    sw.Stop();
                    ts = sw.Elapsed;
                    ViewBag.Message = ts;
                }
            }
            //use ElementAt for searching
            return View("Index");
        }
        public ActionResult goToMain()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}