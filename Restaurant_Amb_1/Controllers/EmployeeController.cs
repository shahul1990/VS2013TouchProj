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
    public class EmployeeController : Controller
    {
        private HotTouchRestEntities db = new HotTouchRestEntities();

        // GET: /Employee/
        public async Task<ActionResult> Index()
        {
            return View(await db.Employee_Tbl.ToListAsync());
        }

        // GET: /Employee/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Tbl employee_tbl = await db.Employee_Tbl.FindAsync(id);
            if (employee_tbl == null)
            {
                return HttpNotFound();
            }
            return View(employee_tbl);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="empid,empname,empusername,emppassword,empconfpassword,empcontactno,empmailid,empaddress,dateofjoining")] Employee_Tbl employee_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Employee_Tbl.Add(employee_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employee_tbl);
        }

        // GET: /Employee/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Tbl employee_tbl = await db.Employee_Tbl.FindAsync(id);
            if (employee_tbl == null)
            {
                return HttpNotFound();
            }
            return View(employee_tbl);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="empid,empname,empusername,emppassword,empconfpassword,empcontactno,empmailid,empaddress,dateofjoining")] Employee_Tbl employee_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employee_tbl);
        }

        // GET: /Employee/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Tbl employee_tbl = await db.Employee_Tbl.FindAsync(id);
            if (employee_tbl == null)
            {
                return HttpNotFound();
            }
            return View(employee_tbl);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee_Tbl employee_tbl = await db.Employee_Tbl.FindAsync(id);
            db.Employee_Tbl.Remove(employee_tbl);
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
