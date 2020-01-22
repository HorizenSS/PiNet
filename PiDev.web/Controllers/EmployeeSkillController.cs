
using PiDev.Domain;
using PiDev.Service;
using PiDev.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Controllers
{
    public class EmployeeSkillController : Controller
    {
        EmployeeSkillService sd = new EmployeeSkillService();
        SkillService sa = new SkillService();

        EmployeService sc = new EmployeService();

      
        public ActionResult Index()
        {
            var EmployeeSkills = sd.GetMany();

            return View(EmployeeSkills);
        }

      
        [HttpPost]
        public ActionResult Index(string SearchSkill)
        {
            var employeeSkills = sd.GetMany(d => d.skill.name.Contains(SearchSkill));

            return View(employeeSkills);
        }

        // GET: Dossier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dossier/Create
        public ActionResult Create()
        {
            var dm = new EmployeeSkillVM();
            dm.skills = sa.GetMany().
                          Select(av =>
                          new SelectListItem
                          {
                              //     Selected = (prod.ProducteurId == selectedId),
                              Text = av.name,
                              Value = av.skillId.ToString()
                          });
            dm.employes = sc.GetMany().
                          Select(cl =>
                          new SelectListItem
                          {
                              //     Selected = (prod.ProducteurId == selectedId),
                              Text = cl.email,
                              Value = cl.cin.ToString()
                          });
            return View(dm);
        }

        // POST: Dossier/Create
        [HttpPost]
        public ActionResult Create(EmployeeSkillVM dm)
        {
            EmployeeSkill d = new EmployeeSkill
            {

                level = dm.level,
                skillFK = dm.skillFK,
               employeFK = dm.employeFK,
                DateAssigned = DateTime.Today,
                Description =dm.Description};
            sd.Add(d);
            sd.Commit();
            return RedirectToAction("Index");


        }

        // GET: Dossier/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSkill p = sd.GetById(id);

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: Dossier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeSkill p)
        {
            if (!ModelState.IsValid)
            {
                return EditDetails();
            }

            if (ModelState.IsValid)
            {

                sd.Update(p);
                sd.Commit();
                sd.Dispose();

                return RedirectToAction("Index");
            }
            return View(p);
        }
        public ActionResult EditDetails()
        {


            return View();

        }
        // GET: Dossier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dossier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


       
    }
}
