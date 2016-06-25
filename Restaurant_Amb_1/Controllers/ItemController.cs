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
using System.IO;

namespace Restaurant_Amb_1.Controllers
{
    public class ItemController : Controller
    {
        private HotTouchRestEntities2 db = new HotTouchRestEntities2();

        // GET: /Item/
        public async Task<ActionResult> Index()
        {
            return View(await db.Item_Tbl.ToListAsync());   
        }

        // GET: /Item/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Tbl item_tbl = await db.Item_Tbl.FindAsync(id);
            if (item_tbl == null)
            {
                return HttpNotFound();
            }
            return View(item_tbl);
        }

        // GET: /Item/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: /Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="itemid,iname,idesc,itype,iimage,iprice,icategory,createdby,createddate,updatedby,updateddate")] Item_Tbl item_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Item_Tbl.Add(item_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item_tbl);
        }

        // GET: /Item/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Tbl item_tbl = await db.Item_Tbl.FindAsync(id);
            if (item_tbl == null)
            {
                return HttpNotFound();
            }
            return View(item_tbl);
        }

        // POST: /Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="itemid,iname,idesc,itype,iimage,iprice,icategory,createdby,createddate,updatedby,updateddate")] Item_Tbl item_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item_tbl);
        }

        // GET: /Item/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Tbl item_tbl = await db.Item_Tbl.FindAsync(id);
            if (item_tbl == null)
            {
                return HttpNotFound();
            }
            return View(item_tbl);
        }

        // POST: /Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item_Tbl item_tbl = await db.Item_Tbl.FindAsync(id);
            db.Item_Tbl.Remove(item_tbl);
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

        //++++++++++++++++++++++++++++++++++++=

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/Upload/"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Admin");
        }
    }
}
