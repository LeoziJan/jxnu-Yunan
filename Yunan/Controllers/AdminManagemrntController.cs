using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using System.Data;

namespace Yunan.Controllers
{
    public class AdminManagemrntController : Controller
    {
        private YunanEntities db = new YunanEntities();
        // GET: AdminManagemrnt
        public async  Task<ActionResult> Index()
        {
            return View(await db.Admins.Where(u => u.AdminFlag == 0).ToListAsync());
        }

        // GET: AdminManagemrnt/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            //参数不正确，直接抛出对应的HttpStatusCodeResult结果
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admins admins = await db.Admins.FindAsync(id);
            //判断是否为空
            if(admins == null)
            {
                return HttpNotFound();
            }
            return View(admins);
        }

        // GET: AdminManagemrnt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminManagemrnt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="AdminId,AdminPassward,AdminName,AdminFlag,HeadImg")] Admins admins)
        {
            
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Admins.Add(admins);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                 }

            return View(admins);
            
        }
        // GET: AdminManagemrnt/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admins admins = await db.Admins.FindAsync(id);
            //判断是否为空
            if (admins == null)
            {
                return HttpNotFound();
            }
            return View(admins);
        }

        // POST: AdminManagemrnt/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AdminId,AdminPassward,AdminName,AdminFlag,HeadImg")] Admins admins)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Entry(admins).State = System.Data.Entity.EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(admins);
            }
        }

        // GET: AdminManagemrnt/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admins admins = await db.Admins.FindAsync(id);
            //判断是否为空
            if (admins == null)
            {
                return HttpNotFound();
            }
            return View(admins);
        }

        // POST: AdminManagemrnt/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Admins admin = await db.Admins.FindAsync(id);
            db.Admins.Remove(admin);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
