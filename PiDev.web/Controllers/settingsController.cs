using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Infrastructure;
using PiDev.Domain.Entities;
using PiDev.ServicePattern;

namespace PiDev.web.Controllers
{
    public class settingsController : Controller
    {
        private Model1 db = new Model1();
     
       

        // GET: settings
        public ActionResult Index()
        {
            return View(db.settings.ToList());
        }

        // GET: settings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            settings settings = db.settings.Find(id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        // GET: settings/Create
        public ActionResult Create()
        {
            return View();
        }
/*
        // POST: settings/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,breakTime_hours,breakTime_minutes,dailyLimit_hours,dailyLimit_minutes,doubleOvertimeRate,overtimeRate,regularRate,weeklyLimit_hours,weeklyLimit_minutes")] settings settings)
        {
            if (ModelState.IsValid)
            {
                db.settings.Add(settings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(settings);
        }

        // GET: settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            settings settings = db.settings.Find(id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }
      */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,breakTime_hours,breakTime_minutes,dailyLimit_hours,dailyLimit_minutes,doubleOvertimeRate,overtimeRate,regularRate,weeklyLimit_hours,weeklyLimit_minutes")] settings settings)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IServices<settings> fService = new Service<settings>(Uok);
            if (ModelState.IsValid)
            {
                fService.Add(settings);
                fService.Commit();
                return RedirectToAction("Index");
            }

            return View(settings);
        }

        /*
        // POST: settings/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,breakTime_hours,breakTime_minutes,dailyLimit_hours,dailyLimit_minutes,doubleOvertimeRate,overtimeRate,regularRate,weeklyLimit_hours,weeklyLimit_minutes")] settings settings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(settings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(settings);
        }
        */
        // GET: Promotion/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            settings question = db.settings.Find(id);

            if (question == null)
            {
                return HttpNotFound();
            }
            
            return View(question);
        }
        // POST: Promotion/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,breakTime_hours,breakTime_minutes,dailyLimit_hours,dailyLimit_minutes,doubleOvertimeRate,overtimeRate,regularRate,weeklyLimit_hours,weeklyLimit_minutes")] settings settings)
        {/*

             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             IDatabaseFactory Factory = new DatabaseFactory();
             IUnitOfWork Uok = new UnitOfWork(Factory);
             IServices<settings> fService = new Service<settings>(Uok);
             settings u = fService.GetById((int)id);
             if (u == null)
             {
                 return HttpNotFound();
             }
             return View(u);
         }
        */
            DatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IServices<settings> QService = new Service<settings>(Uok);
            //IEnumerable<PointeVente> c = collection.Cast<PointeVente>();
            QService.Update(settings);
            QService.Commit();
            return RedirectToAction("Index");
        }
        // GET: settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            settings settings = db.settings.Find(id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        // POST: settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {/*
            settings settings = db.settings.Find(id);
            db.settings.Remove(settings);
            db.SaveChanges();
            return RedirectToAction("Index");
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IServices<settings> QService = new Service<settings>(Uok);
            QService.Delete(QService.GetById(id));
            QService.Commit();

            return RedirectToAction("Index");*/
            //try again bb
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IServices<settings> QService = new Service<settings>(Uok);
            List<timesheet> appo = new List<timesheet>();
            IServices<timesheet> jbService = new Service<timesheet>(Uok);
            List<timesheet> j = new List<timesheet>();
            appo = jbService.GetAll().ToList();
            for (int i = appo.Count - 1; i >= 0; i--)
            {
                if (appo[i].settings_id == id)
                {

                    j.Remove(appo[i]);

                }

            }
            //----
            QService.Delete(QService.GetById(id));
            QService.Commit();

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
