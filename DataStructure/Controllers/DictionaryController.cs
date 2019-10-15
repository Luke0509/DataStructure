using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructure.Controllers
{
    public class DictionaryController : Controller
    {
        // GET: Dictionary
        //create new Dictionary
        public static Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        
        public ActionResult Index()
        {
            return View();
        }
        //add a new entry with incrementing count
        public ActionResult addOne()
        {
            myDictionary.Add(myDictionary.Count() + 1, "New Entry #" + (myDictionary.Count() + 1));
            ViewBag.Message = "One item added successfully!";
            return View("Index");
        }
        //add 2000 items to the dictionary
        public ActionResult hugeList()
        {
            //clear dictionary
            myDictionary.Clear();
            //for loop to add 2000 entries
            for (int iCount = 1; iCount <= 2000; iCount++)
            {
                myDictionary.Add(myDictionary.Count() + 1, "New Entry #" + (myDictionary.Count() + 1));
            }
            ViewBag.Message = "2000 items added to queue!";
            return View("Index");
        }
        public ActionResult display()
        {
            //display dictionary
            ViewBag.myData = myDictionary;
            return View("Display");
        }
        public ActionResult delete()
        {
            if (myDictionary.Count == 0) //if it is empty, show error
            {
                ViewBag.Message = "There is nothing to delete";
            }
            else // if not, remove the value at the highest key
            {
                myDictionary.Remove(myDictionary.Count());
                ViewBag.Message = "One item deleted!";
            }
            return View("Index");
        }
        //clears all items from dictionary
        public ActionResult clear()
        {
            myDictionary.Clear();
            ViewBag.Message = "Dictionary cleared.";
            return View("Index");
        }
        public ActionResult search()
        {
            int searchKey = 7; // looking for key "7"​
            //stopwatch
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            TimeSpan ts;
            sw.Start();

            if (myDictionary.Count() > 0)
            {
                if (myDictionary.ContainsKey(searchKey))//if it is found
                {
                    sw.Stop();
                    ts = sw.Elapsed;
                    ViewBag.Message = ts + " to find the item";
                }
                else//if it is not found
                {
                    sw.Stop();
                    ts = sw.Elapsed;
                    ViewBag.Message = ts + " has elapsed, and the item was not found";
                    
                }
            }
            else
            {
                ViewBag.Message = "The dictionary is empty. Nothing to search";
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