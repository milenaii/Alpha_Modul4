using ModelBinders_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinders_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        ///// ModelBinders_Demo

        [HttpGet]
        public ActionResult ProfileTest()
        {
            ProfileViewModel viewModel = new ProfileViewModel()
            {
                FirstName = "Gosho",
                Age = 35,
                
            };

            return this.View(viewModel);
        }
        //1 -  just values

        //[HttpPost]
        //public ActionResult ProfileTest(string firstName, int age)
        //{
        //    return this.View();
        //}

        //2 - object with these prop

        //[HttpPost]
        public ActionResult ProfileTest(ProfileViewModel viewModel)
        {
            return this.View();
        }

        public ActionResult ProfileView()
        {

            ProfileViewModel viewModel = new ProfileViewModel()
            {
                FirstName = "Pesho",
                Age = 40,

            };
            return this.View(viewModel);
        }


        ///// ModelBinders_Demo


    }
}