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
    public class PickupController : Controller
    {
        private HotTouchRestEntities2 db = new HotTouchRestEntities2();

        // GET: /Pickup/
        public async Task<ActionResult> Index()
        {
            return View(await db.Pickup_Tbl.ToListAsync());
        }

        // GET: /Pickup/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickup_Tbl pickup_tbl = await db.Pickup_Tbl.FindAsync(id);
            if (pickup_tbl == null)
            {
                return HttpNotFound();
            }
            return View(pickup_tbl);
        }

        // GET: /Pickup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Pickup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="storeid,storelocation,sotrecity,storecontact1,storecontact2,storecontact3,createdby,createddate,updatedby,updateddate")] Pickup_Tbl pickup_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Pickup_Tbl.Add(pickup_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pickup_tbl);
        }

        // GET: /Pickup/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickup_Tbl pickup_tbl = await db.Pickup_Tbl.FindAsync(id);
            if (pickup_tbl == null)
            {
                return HttpNotFound();
            }
            return View(pickup_tbl);
        }

        // POST: /Pickup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="storeid,storelocation,sotrecity,storecontact1,storecontact2,storecontact3,createdby,createddate,updatedby,updateddate")] Pickup_Tbl pickup_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickup_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pickup_tbl);
        }

        // GET: /Pickup/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickup_Tbl pickup_tbl = await db.Pickup_Tbl.FindAsync(id);
            if (pickup_tbl == null)
            {
                return HttpNotFound();
            }
            return View(pickup_tbl);
        }

        // POST: /Pickup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pickup_Tbl pickup_tbl = await db.Pickup_Tbl.FindAsync(id);
            db.Pickup_Tbl.Remove(pickup_tbl);
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
