using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PiDev.Domain;
using PiDev.Domain;

namespace PiDev.web.Controllers
{/*
    public class positionOffersController : Controller
    {
        private PidevContext db = new PidevContext();

        // GET: positionOffers
        public async Task<ActionResult> Index()
        {
            return View(await db.positionOffers.ToListAsync());
        }

        // GET: positionOffers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            positionOffer positionOffer = await db.positionOffers.FindAsync(id);
            if (positionOffer == null)
            {
                return HttpNotFound();
            }
            return View(positionOffer);
        }

        // GET: positionOffers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: positionOffers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPositionOffer,Description,EndDate,Name,Priority,StartDate,Type,DocumentsUrl")] positionOffer positionOffer)
        {
            if (ModelState.IsValid)
            {
                db.positionOffers.Add(positionOffer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(positionOffer);
        }

        // GET: positionOffers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            positionOffer positionOffer = await db.positionOffers.FindAsync(id);
            if (positionOffer == null)
            {
                return HttpNotFound();
            }
            return View(positionOffer);
        }

        // POST: positionOffers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPositionOffer,Description,EndDate,Name,Priority,StartDate,Type,DocumentsUrl")] positionOffer positionOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(positionOffer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(positionOffer);
        }

        // GET: positionOffers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            positionOffer positionOffer = await db.positionOffers.FindAsync(id);
            if (positionOffer == null)
            {
                return HttpNotFound();
            }
            return View(positionOffer);
        }

        // POST: positionOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            positionOffer positionOffer = await db.positionOffers.FindAsync(id);
            db.positionOffers.Remove(positionOffer);
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
*/}
