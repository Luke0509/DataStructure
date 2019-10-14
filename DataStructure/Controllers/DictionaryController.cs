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

        public static Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addOne()
        {
            //myDictionary.add(myDictionary.Count, "the text"));
            return View("Index");
        }
        public ActionResult hugeList()
        {
            return View("Index");
        }
        public ActionResult display()
        {
            //keyvaluepair
            return View("Index");
        }
        public ActionResult delete()
        {
            //use .Remove
            return View("Index");
        }
        public ActionResult clear()
        {
            myDictionary.Clear();
            return View("Index");
        }
        public ActionResult search()
        {
            //forreach on keyvalue
            return View("Index");
        }
        public ActionResult goToMain()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}