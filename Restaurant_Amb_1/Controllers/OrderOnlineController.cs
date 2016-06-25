using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_Amb_1.Models;

namespace Restaurant_Amb_1.Views.OrderOnline
{
    public class OrderOnlineController : Controller
    {
        HotTouchRestEntities2 db = new HotTouchRestEntities2();
        //
        // GET: /OrderOnline/
        public ActionResult Index()
        {
         //   ViewBag.listcategory = db.Category_Tbl.ToList();
            return View();
        }
	}
}