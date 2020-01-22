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
using System.Collections;
using Newtonsoft.Json;
using PiDev.Service.Services;

namespace PiDev.web.Controllers
{
    public class TargetSkillsController : Controller
    {
        private PidevContext db = new PidevContext();
        TargetSkillService ts = new TargetSkillService();
        // GET: TargetSkills
        public async Task<ActionResult> Index()
        {
            var targetSkills = db.TargetSkills.Include(t => t.Employe).Include(t => t.JobOffer);
            return View(await targetSkills.ToListAsync());
        }

        // GET: TargetSkills/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetSkill targetSkill = await db.TargetSkills.FindAsync(id);
            if (targetSkill == null)
            {
                return HttpNotFound();
            }
            return View(targetSkill);
        }

        // GET: TargetSkills/Create
        public ActionResult Create()
        {
            ViewBag.cin = new SelectList(db.employes, "cin", "email");
            ViewBag.idJobOffer = new SelectList(db.jobOffer, "IdJobOffer", "Name");
            return View();
        }

        // POST: TargetSkills/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "targetId,Name,Description,idJobOffer,DeadLine,StartDate,state,cin")] TargetSkill targetSkill)
        {
            if (ModelState.IsValid)
            {
                db.TargetSkills.Add(targetSkill);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cin = new SelectList(db.employes, "cin", "email", targetSkill.cin);
            ViewBag.idJobOffer = new SelectList(db.jobOffer, "IdJobOffer", "Name", targetSkill.idJobOffer);
            return View(targetSkill);
        }

        // GET: TargetSkills/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetSkill targetSkill = await db.TargetSkills.FindAsync(id);
            if (targetSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.cin = new SelectList(db.employes, "cin", "email", targetSkill.cin);
            ViewBag.idJobOffer = new SelectList(db.jobOffer, "IdJobOffer", "Name", targetSkill.idJobOffer);
            return View(targetSkill);
        }

        // POST: TargetSkills/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "targetId,Name,Description,idJobOffer,DeadLine,StartDate,state,cin")] TargetSkill targetSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(targetSkill).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cin = new SelectList(db.employes, "cin", "email", targetSkill.cin);
            ViewBag.idJobOffer = new SelectList(db.jobOffer, "IdJobOffer", "Name", targetSkill.idJobOffer);
            return View(targetSkill);
        }

        // GET: TargetSkills/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetSkill targetSkill = await db.TargetSkills.FindAsync(id);
            if (targetSkill == null)
            {
                return HttpNotFound();
            }
            return View(targetSkill);
        }

        // POST: TargetSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TargetSkill targetSkill = await db.TargetSkills.FindAsync(id);
            db.TargetSkills.Remove(targetSkill);
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

        public ActionResult qualificationStat()
        {
           int idJobOffer = 5;

            string jobname = ts.FindNamejobOfferById(idJobOffer);
            string DeadlineInfo = ts.jobOfferDeadlineVerification(idJobOffer);
            // prepare a 2d array in c#
            ArrayList header = new ArrayList { "qualification State", "Number" };
            ArrayList data1 = new ArrayList { "NotAquired", ts.numberOfNotStartedTargetSkillsByjobOffer(idJobOffer) };
            ArrayList data2 = new ArrayList { "Learning", ts.numberOfInProgressTargetSkillsByjobOffer(idJobOffer) };
            ArrayList data3 = new ArrayList { "Mastered", ts.numberOfAccomplishTargetSkillsByjobOffer(idJobOffer) };
            ArrayList data = new ArrayList { header, data1, data2, data3 };
            // convert it in json
            string dataStr = JsonConvert.SerializeObject(data, Formatting.None);
            // store it in viewdata/ viewbag
            ViewBag.Data = new HtmlString(dataStr);
            ViewData["jobname"] = jobname;
            ViewData["DeadlineInfo"] = DeadlineInfo;
            return View();
        }

        public ActionResult globalView()
        {


            return View();
        }


        public ActionResult DeadlineVerification(int IdJobOffer)
        {
           

            string jobname = ts.FindNamejobOfferById(IdJobOffer);
            string DeadlineInfo = ts.jobOfferDeadlineVerification(IdJobOffer);
            ViewData["jobname"] = jobname;
            ViewData["DeadlineInfo"] = DeadlineInfo;
            return View();
        }
        }
}
