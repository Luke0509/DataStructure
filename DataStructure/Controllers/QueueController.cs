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
        //adds one item to the queue
        public ActionResult addOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.myData = myQueue;
            ViewBag.Message = "One item added successfully!";
            return View("Index");
        }
        //add 2000 items to the queue and tells the user it was successful
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
        //displays all entries in the queue
        public ActionResult display()
        {
            ViewBag.myData = myQueue;
            return View("Display");
        }
        //deletes an item from queue or tells user there are none to delete
        public ActionResult delete()
        {
            if (myQueue.Any())
            {
                myQueue.Dequeue();
                ViewBag.Message = "One item deleted!";
            }
            else
            {
                ViewBag.Message = "There are no items to delete!";
            }
            return View("Index");
        }
        //clears all items from the queue
        public ActionResult clear()
        {
            myQueue.Clear();
            ViewBag.myData = myQueue;
            ViewBag.Message = "Queue cleared.";
            return View("Index");
        }
        //searches queue for hard coded number and posts time it took to find it if it is there
        public ActionResult search()
        {
            string searchVar = "New Entry 40";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            TimeSpan ts;
            sw.Start();
            Boolean bFound = false;
            if (myQueue.Count > 0)
            {
                for (int iCount = 0; iCount < myQueue.Count(); iCount++) //loop through queue
                {
                    if (myQueue.ElementAt(iCount) == searchVar) //compare current value in queue to hard coded value
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
                    ViewBag.Message = ts + " has elapsed, and the item was not found";
                }
            }
            else
            {
                ViewBag.Message = "The Queue is empty. Nothing to search";
            }
            return View("Index");
        }
        //return to main menu
        public ActionResult goToMain()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}