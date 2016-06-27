using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_Amb_1.Models;
using Restaurant_Amb_1.ViewModels;

namespace Restaurant_Amb_1.Views.OrderOnline
{
    public class OrderOnlineController : Controller
    {
        HotTouchRestEntities2 db = new HotTouchRestEntities2();
        //
        // GET: /OrderOnline/
        public ActionResult Index()
        {
            //var category = db.Category_Tbl.ToList();
            //ViewData["cat"] = category;
         //   ViewBag.listcategory = db.Category_Tbl.ToList();
            return View();
        }
	}
}