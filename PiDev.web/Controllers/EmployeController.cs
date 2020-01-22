using Data;
using PiDev.Domain;
using PiDev.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Controllers
{
    public class EmployeController : Controller
    {
        private PidevContext db = new PidevContext();
        EmployeeSkillService sd = new EmployeeSkillService();
        SkillService sk = new SkillService();
        // GET: employes
        public ActionResult Index()
        {
            return View(db.employes.ToList());
        }


        [HttpPost]
        public ActionResult Index(string searchEmploye)
        {

            List<employe> jobOffer = sd.employesSkillExperience(searchEmploye).ToList();
            List<employe> pr = new List<employe>();
            foreach (var item in jobOffer)
            {
                pr.Add(
                    new employe
                    {
                        cin = item.cin,
                        email = item.email,
                        firstName = item.firstName,
                        lastName = item.lastName,
                        birthDate = item.birthDate,
                        Address = item.Address,
                        role = item.role,
                        salary = item.salary,
                        password=item.password,
                        phoneNb=item.phoneNb
                       

                    });

            }


            return View(pr);
        }
        // GET: employes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employe employe = db.employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // GET: employes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,email,password,role")] employe employe)
        {
            if (ModelState.IsValid)
            {
                db.employes.Add(employe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employe);
        }

        // GET: employes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employe employe = db.employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: employes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,email,password,role")] employe employe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employe);
        }

        // GET: employes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employe employe = db.employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employe employe = db.employes.Find(id);
            db.employes.Remove(employe);
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

      
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /employes/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Password,Email")] employe employe)
        {
            if (ModelState.IsValid)
            {
                EmployeService us = new EmployeService();
                employe employe3 = us.FindRoleByName(employe.email);
                if (employe.password == employe3.password)
                {
                    Session["empID"] = employe.cin;
                    if (employe3.role == "manager")
                    {
                       

                        return RedirectToAction("loginManager");
                    }
                    else if (employe3.role == "hr")
                    {
                      
                        return RedirectToAction("loginHr");
                    }
                    else if (employe3.role == "employe")
                    {
                     
                        return RedirectToAction("loginEmploye");
                    }
                    else
                    {
                        return View(employe);
                    }
                }


            }

            return View(employe);
        }

        public ActionResult loginManager()
        {



            return RedirectToAction("ManagerIndex", "Employe");

        }
        public ActionResult loginHr()
        {



            return RedirectToAction("HRIndex", "Employe");

        }
        public ActionResult loginEmploye()
        {



            return RedirectToAction("EmployeIndex", "Employe");

        }

        public ActionResult ManagerIndex() { return View(); }
        public ActionResult HRIndex() { return View(); }
        public ActionResult EmployeIndex() { return View(); }


       


     
    }
}
