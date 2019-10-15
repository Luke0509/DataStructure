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
        //incrementally adds an item to the stack
        public ActionResult addOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.myData = myStack;
            ViewBag.Message = "One item added successfully!";
            return View("Index");
        }
        //adds 2000 items to the stack 
        public ActionResult hugeList()
        {
            myStack.Clear();
            for(int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            }
            ViewBag.myData = myStack;
            ViewBag.Message = "2000 items added to stack!";
            return View("Index");
        }
        //puts stack into viewbag to display it
        public ActionResult display()
        {
            ViewBag.myData = myStack;
            return View("Display");
        }
        //if stack has items, delete one. if not, inform the user
        public ActionResult delete()
        {
            if (myStack.Any())
            {
                myStack.Pop();
                ViewBag.Message = "One item deleted!";
            }
            else
            {
                ViewBag.Message = "There were no items to delete!";
            }
            return View("Index");
        }
        //removes all items from the stack
        public ActionResult clear()
        {
            myStack.Clear();
            ViewBag.myData = myStack;
            ViewBag.Message = "Stack cleared.";
            return View("Index");
        }
        //searches stack for hard coded number and posts time it took to find it if it is there
        public ActionResult search()
        {
            string searchVar = "New Entry 40";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            TimeSpan ts;
            sw.Start();
            Boolean bFound = false;

            if (myStack.Count > 0)
            {
                for (int iCount = 0; iCount < myStack.Count(); iCount++) //loop through stack
                {
                    if (myStack.ElementAt(iCount) == searchVar) //check if this is the value
                    {
                        sw.Stop();
                        ts = sw.Elapsed;
                        ViewBag.Message = ts + " to find the item";
                        bFound = true;
                        iCount = myStack.Count();
                    }
                }
                if(bFound == false)
                {
                    sw.Stop();
                    ts = sw.Elapsed;
                    ViewBag.Message = ts + " has elapsed, and the item was not found";
                }
                
            }
            else
            {
                ViewBag.Message = "The Stack is empty. Nothing to search";
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