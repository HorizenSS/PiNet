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
using Service.Pattern;
using PiDev.Service;

namespace PiDev.web.Controllers
{
    public class questionsController : Controller
    {
        private Context db = new Context();

        // GET: questions
        public ActionResult Index()
        {
            /*var question = db.question.Include(q => q.test);
            return View(question.ToList());*/
            return View(db.question.ToList());
            
        }

        // GET: questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question question = db.question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: questions/Create
        public ActionResult Create()
        {
            //ana na7etha
            ViewBag.testt_idTest = new SelectList(db.test, "idTest", "descriptionTest");
            return View();
        }

        // POST: questions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idQues,quesText,testt_idTest")] question question)
        {
            /* if (ModelState.IsValid)
             {
                 db.question.Add(question);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             ViewBag.testt_idTest = new SelectList(db.test, "idTest", "descriptionTest", question.testt_idTest);
             return View(question);*/

            IDataBaseFactory Factory = new DataBaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<question> questionService = new Service<question>(Uok);
            if (ModelState.IsValid)
            {
                questionService.Add(question);
                questionService.Commit();
                return RedirectToAction("Index");
            }
            //ViewBag.testt_idTest = new SelectList(db.test, "idTest", "descriptionTest", question.testt_idTest);
            return View(question);
        }

        // GET: questions/Edit/5
        public ActionResult Edit(int? id)
        {
            /* if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             question question = db.question.Find(id);
             if (question == null)
             {
                 return HttpNotFound();
             }
             ViewBag.testt_idTest = new SelectList(db.test, "idTest", "descriptionTest", question.testt_idTest);
             return View(question);*/

            //hello
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             question question = db.question.Find(id);

             if (question == null)
             {
                 return HttpNotFound();
             }
             ViewBag.testt_idTest = new SelectList(db.test, "idTest", "descriptionTest", question.testt_idTest);
             return View(question);
            
        }

        // POST: questions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idQues,quesText,testt_idTest")] question question)
        {
            /* if (ModelState.IsValid)
             {
                 db.Entry(question).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             ViewBag.testt_idTest = new SelectList(db.test, "idTest", "descriptionTest", question.testt_idTest);
             return View(question);*/
            /* if (ModelState.IsValid)
             {
                 db.Entry(question).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             return View(question);*/

            //tejrba
            IDataBaseFactory Factory = new DataBaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<question> QService = new Service<question>(Uok);
            QService.Update(question);
            QService.Commit();
            return RedirectToAction("Index");
        }

        // GET: questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question question = db.question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.testt_idTest = new SelectList(db.test, "idTest", "descriptionTest", question.testt_idTest);
            return View(question);
        }

        // POST: questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /* question question = db.question.Find(id);
             db.question.Remove(question);
             db.SaveChanges();
             return RedirectToAction("Index");*/

            IDataBaseFactory Factory = new DataBaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<question> QService = new Service<question>(Uok);
            // IService<reponse> RService = new Service<reponse>(Uok);
            // RService.Delete(RService.GetById(id));
            //zyede
            /*IQuestion RrService = new questionService(Uok) ;
            RrService.reponseD(id);*/
            //db.SaveChanges();
            //---

            //try again bb
            List<reponse> appo = new List<reponse>();
            IService<reponse> jbService = new Service<reponse>(Uok);
            List<reponse> j = new List<reponse>();
            appo = jbService.GetAll().ToList() ;
            for (int i = appo.Count - 1; i >= 0; i--)
            {
                if (appo[i].quest_idQues == id)
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
