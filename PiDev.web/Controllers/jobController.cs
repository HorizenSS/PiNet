using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using PiDev.Domain;

namespace PiDev.web.Controllers
{
    public class jobController : Controller
    {
        private PidevContext db = new PidevContext();

        // GET: job
        public async Task<ActionResult> Index()
        {
            return View(await db.jobOffer.ToListAsync());
        }

        // GET: job/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobOffer jobOffer = await db.jobOffer.FindAsync(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // GET: job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: job/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdJobOffer,Description,EndDate,Name,salary,StartDate,DocumentsUrl")] jobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                db.jobOffer.Add(jobOffer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jobOffer);
        }

        // GET: job/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobOffer jobOffer = await db.jobOffer.FindAsync(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // POST: job/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdJobOffer,Description,EndDate,Name,salary,StartDate,DocumentsUrl")] jobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobOffer).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobOffer);
        }

        // GET: job/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobOffer jobOffer = await db.jobOffer.FindAsync(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // POST: job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            jobOffer jobOffer = await db.jobOffer.FindAsync(id);
            db.jobOffer.Remove(jobOffer);
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
