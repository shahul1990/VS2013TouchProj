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
    public class CategoryController : Controller
    {
        private HotTouchRestEntities db = new HotTouchRestEntities();

        
        // GET: /Default1/
        public async Task<ActionResult> Index()
        {
            return View(await db.Category_Tbl.ToListAsync());
        }

        // GET: /Default1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Tbl category_tbl = await db.Category_Tbl.FindAsync(id);
            if (category_tbl == null)
            {
                return HttpNotFound();
            }
            return View(category_tbl);
        }

        // GET: /Default1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="categoryid,categoryname,categorydesc,createdby,createddate,updatedby,updateddate")] Category_Tbl category_tbl)
        {
            if(ModelState.IsValid)
            {
                db.Category_Tbl.Add(category_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category_tbl);
        }

        // GET: /Default1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Tbl category_tbl = await db.Category_Tbl.FindAsync(id);
            if (category_tbl == null)
            {
                return HttpNotFound();
            }
            return View(category_tbl);
        }

        // POST: /Default1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="categoryid,categoryname,categorydesc,createdby,createddate,updatedby,updateddate")] Category_Tbl category_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category_tbl);
        }

        // GET: /Default1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Tbl category_tbl = await db.Category_Tbl.FindAsync(id);
            if (category_tbl == null)
            {
                return HttpNotFound();
            }
            return View(category_tbl);
        }

        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category_Tbl category_tbl = await db.Category_Tbl.FindAsync(id);
            db.Category_Tbl.Remove(category_tbl);
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
