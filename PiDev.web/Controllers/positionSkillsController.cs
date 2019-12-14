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
    public class positionSkillsController : Controller
    {
        private PidevContext db = new PidevContext();

        // GET: positionSkills
        public async Task<ActionResult> Index()
        {
            var positionSkills = db.positionSkills.Include(p => p.positionOffer);
            return View(await positionSkills.ToListAsync());
        }

        // GET: positionSkills/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            positionSkill positionSkill = await db.positionSkills.FindAsync(id);
            if (positionSkill == null)
            {
                return HttpNotFound();
            }
            return View(positionSkill);
        }

        // GET: positionSkills/Create
        public ActionResult Create()
        {
            ViewBag.idPositionOffer = new SelectList(db.positionOffers, "IdPositionOffer", "Description");
            return View();
        }

        // POST: positionSkills/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Description,idPositionOffer,DeadLine,StartDate,state")] positionSkill positionSkill)
        {
            if (ModelState.IsValid)
            {
                db.positionSkills.Add(positionSkill);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idPositionOffer = new SelectList(db.positionOffers, "IdPositionOffer", "Description", positionSkill.idPositionOffer);
            return View(positionSkill);
        }

        // GET: positionSkills/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            positionSkill positionSkill = await db.positionSkills.FindAsync(id);
            if (positionSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPositionOffer = new SelectList(db.positionOffers, "IdPositionOffer", "Description", positionSkill.idPositionOffer);
            return View(positionSkill);
        }

        // POST: positionSkills/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Description,idPositionOffer,DeadLine,StartDate,state")] positionSkill positionSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(positionSkill).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idPositionOffer = new SelectList(db.positionOffers, "IdPositionOffer", "Description", positionSkill.idPositionOffer);
            return View(positionSkill);
        }

        // GET: positionSkills/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            positionSkill positionSkill = await db.positionSkills.FindAsync(id);
            if (positionSkill == null)
            {
                return HttpNotFound();
            }
            return View(positionSkill);
        }

        // POST: positionSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            positionSkill positionSkill = await db.positionSkills.FindAsync(id);
            db.positionSkills.Remove(positionSkill);
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
