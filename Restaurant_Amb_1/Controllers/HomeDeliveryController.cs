using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurant_Amb_1;

namespace Restaurant_Amb_1.Controllers
{
    public class HomeDeliveryController : Controller
    {
        private HotTouchRestEntities db = new HotTouchRestEntities();

        // GET: /HomeDelivery/
        public async Task<ActionResult> Index()
        {
            return View(await db.HomeDelivery_Tbl.ToListAsync());
        }

        // GET: /HomeDelivery/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeDelivery_Tbl homedelivery_tbl = await db.HomeDelivery_Tbl.FindAsync(id);
            if (homedelivery_tbl == null)
            {
                return HttpNotFound();
            }
            return View(homedelivery_tbl);
        }

        // GET: /HomeDelivery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /HomeDelivery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="homdelid,homdellocation,homdelcity,createdby,createddate,updatedby,updateddate")] HomeDelivery_Tbl homedelivery_tbl)
        {
            if (ModelState.IsValid)
            {
                db.HomeDelivery_Tbl.Add(homedelivery_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(homedelivery_tbl);
        }

        // GET: /HomeDelivery/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeDelivery_Tbl homedelivery_tbl = await db.HomeDelivery_Tbl.FindAsync(id);
            if (homedelivery_tbl == null)
            {
                return HttpNotFound();
            }
            return View(homedelivery_tbl);
        }

        // POST: /HomeDelivery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="homdelid,homdellocation,homdelcity,createdby,createddate,updatedby,updateddate")] HomeDelivery_Tbl homedelivery_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homedelivery_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(homedelivery_tbl);
        }

        // GET: /HomeDelivery/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeDelivery_Tbl homedelivery_tbl = await db.HomeDelivery_Tbl.FindAsync(id);
            if (homedelivery_tbl == null)
            {
                return HttpNotFound();
            }
            return View(homedelivery_tbl);
        }

        // POST: /HomeDelivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HomeDelivery_Tbl homedelivery_tbl = await db.HomeDelivery_Tbl.FindAsync(id);
            db.HomeDelivery_Tbl.Remove(homedelivery_tbl);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
