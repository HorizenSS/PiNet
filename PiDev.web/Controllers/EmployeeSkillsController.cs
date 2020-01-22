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
using PiDev.Service;

namespace PiDev.web.Controllers
{
    public class EmployeeSkillsController : Controller
    {
        private PidevContext db = new PidevContext();
        EmployeeSkillService sd = new EmployeeSkillService();
        SkillService sa = new SkillService();

        EmployeService sc = new EmployeService();
        // GET: EmployeeSkills
        public async Task<ActionResult> Index()
        {
            var employeeSkills = db.EmployeeSkills.Include(e => e.employe).Include(e => e.skill);
            return View(await employeeSkills.ToListAsync());
        }



        [HttpPost]
        public ActionResult Index(string SearchSkill)
        {
            var employeeSkills = sd.GetMany(d => d.skill.name.Contains(SearchSkill));

            return View(employeeSkills);
        }




        // GET: EmployeeSkills/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSkill employeeSkill = await db.EmployeeSkills.FindAsync(id);
            if (employeeSkill == null)
            {
                return HttpNotFound();
            }
            return View(employeeSkill);
        }

        // GET: EmployeeSkills/Create
        public ActionResult Create()
        {
            ViewBag.employeFK = new SelectList(db.employes, "cin", "email");
            ViewBag.skillFK = new SelectList(db.skill, "skillId", "name");
            return View();
        }

        // POST: EmployeeSkills/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "employeFK,skillFK,DateAssigned,Description,level")] EmployeeSkill employeeSkill)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeSkills.Add(employeeSkill);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.employeFK = new SelectList(db.employes, "cin", "email", employeeSkill.employeFK);
            ViewBag.skillFK = new SelectList(db.skill, "skillId", "name", employeeSkill.skillFK);
            return View(employeeSkill);
        }

        // GET: EmployeeSkills/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSkill employeeSkill = await db.EmployeeSkills.FindAsync(id);
            if (employeeSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeFK = new SelectList(db.employes, "cin", "email", employeeSkill.employeFK);
            ViewBag.skillFK = new SelectList(db.skill, "skillId", "name", employeeSkill.skillFK);
            return View(employeeSkill);
        }

        // POST: EmployeeSkills/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "employeFK,skillFK,DateAssigned,Description,level")] EmployeeSkill employeeSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeSkill).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.employeFK = new SelectList(db.employes, "cin", "email", employeeSkill.employeFK);
            ViewBag.skillFK = new SelectList(db.skill, "skillId", "name", employeeSkill.skillFK);
            return View(employeeSkill);
        }

        // GET: EmployeeSkills/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSkill employeeSkill = await db.EmployeeSkills.FindAsync(id);
            if (employeeSkill == null)
            {
                return HttpNotFound();
            }
            return View(employeeSkill);
        }

        // POST: EmployeeSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmployeeSkill employeeSkill = await db.EmployeeSkills.FindAsync(id);
            db.EmployeeSkills.Remove(employeeSkill);
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
