using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace MVCLearning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string data = "";
            if (TempData["mydata"] != null)
            {
                data = TempData["mydata"] as string;

            }
            TempData["mydata"] = "This is string";
            //Call TempData.Keep() to keep all the values of TempData in a third request.
            TempData.Keep();

            //List<string> Student = new List<string>();
            //Student.Add("Ahmad");
            //Student.Add("Ali");
            //Student.Add("Kamran");

            var students = new List<string>
            {
                "Ahmad",
                "Ali",
                "Kamran"
            };

            ViewBag.Student = students;
         
            return View();
        }

        public ActionResult About()
        {
            string data;

            if (TempData["myData"] != null)
                data = TempData["myData"] as string;

            ViewBag.Message = "Your application description page.";


            var students = new List<string>
            {
                "Ahmad",
                "Ali",
                "Kamran"
            };

            ViewData["students"] = students;
            return View();
        }

        public ActionResult Contact()
        {
            //Now look at one more beauty of MVC, you can put data into the ViewBag and access it from ViewData 
            //or put data in the ViewData and access it from the ViewBag, here you have all the freedom.

            var students = new List<string>
            {
                "Ahmad",
                "Ali",
                "Kamran"
            };

            ViewData["students"] = students;

            ViewBag.Message = "Your contact page.";

            return View();
        }
        public class Product
        {
            public int Id { get; set; }
            public String Name { get; set; }

            public bool Available { get; set; }
        }

        List<Product> lst = new List<Product>()
        {
            new Product{Id=1,Name="Books",Available=true},
            new Product{Id=2,Name="Story Books",Available=true},
            new Product{Id=3,Name="Movies",Available=true},
            new Product{Id=4,Name="Balls",Available=true},
            new Product{Id=5,Name="Games",Available=true},
            new Product{Id=6,Name="Pens",Available=true}
        };

        public ActionResult TestViewModal()
        {
            return View(lst);
        }
    }
}