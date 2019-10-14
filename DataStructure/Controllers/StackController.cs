using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructure.Controllers
{
    public class StackController : Controller
    {
        // GET: Stack

        public static Stack<string> myStack = new Stack<string>();

        public ActionResult Index()
        {
            ViewBag.myData = myStack;
            return View();
        }
        public ActionResult addOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.myData = myStack;
            return View("Index");
        }
        public ActionResult hugeList()
        {
            myStack.Clear();
            for(int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            }
            ViewBag.myData = myStack;
            return View("Index");
        }
        public ActionResult display()
        {
            ViewBag.myData = myStack;

            return View("Display");
        }
        public ActionResult delete()
        {
            //if statement if there is an item, pop return index
            return View("Index");
        }
        public ActionResult clear()
        {
            myStack.Clear();
            ViewBag.myData = myStack;
            return View("Index");
        }
        public ActionResult search()
        {
            string searchVar = "New Entry 420";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            TimeSpan ts;
            sw.Start();
            Boolean bFound = false;

            if (myStack.Count > 0)
            {
                for (int iCount = 0; iCount < myStack.Count(); iCount++)
                {
                    if (myStack.ElementAt(iCount) == searchVar)
                    {
                        sw.Stop();
                        ts = sw.Elapsed;
                        ViewBag.StopWatch = ts;
                        bFound = true;
                        iCount = myStack.Count();
                    }
                }
                if(bFound == false)
                {
                    sw.Stop();
                    ts = sw.Elapsed;
                    ViewBag.StopWatch = ts;
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