﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_Amb_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
          //  ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Menu()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PartyHall()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dinning_Buffets()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Catering()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

     
    }
}