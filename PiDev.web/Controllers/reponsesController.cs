using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using PiDev.Domain.Entities;

namespace PiDev.web.Controllers
{
    public class reponsesController : Controller
    {
        private Context db = new Context();

        // GET: reponses
        public ActionResult Index()
        {
            var reponse = db.reponse.Include(r => r.question);
            return View(reponse.ToList());
        }

        // GET: reponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reponse reponse = db.reponse.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // GET: reponses/Create
        public ActionResult Create()
        {
            ViewBag.quest_idQues = new SelectList(db.question, "idQues", "quesText");
            return View();
        }

        // POST: reponses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRep,description,isValide,quest_idQues")] reponse reponse)
        {
            if (ModelState.IsValid)
            {
                db.reponse.Add(reponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.quest_idQues = new SelectList(db.question, "idQues", "quesText", reponse.quest_idQues);
            return View(reponse);
        }

        // GET: reponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reponse reponse = db.reponse.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.quest_idQues = new SelectList(db.question, "idQues", "quesText", reponse.quest_idQues);
            return View(reponse);
        }

        // POST: reponses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRep,description,isValide,quest_idQues")] reponse reponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.quest_idQues = new SelectList(db.question, "idQues", "quesText", reponse.quest_idQues);
            return View(reponse);
        }

        // GET: reponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reponse reponse = db.reponse.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // POST: reponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reponse reponse = db.reponse.Find(id);
            db.reponse.Remove(reponse);
            db.SaveChanges();
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
