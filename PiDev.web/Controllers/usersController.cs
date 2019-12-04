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
using PiDev.Service;

namespace PiDev.web.Controllers
{
    public class usersController : Controller
    {
        private Model1 db = new Model1();

        // GET: users
        public ActionResult Index()
        {
            var user = db.user.Include(u => u.user2);
            return View(user.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.manager_id = new SelectList(db.user, "id", "Firstname");
            return View();
        }

        // POST: users/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Firstname,LastName,Phone,cin,grade,login,mail,password,rating,role,salary,speciality,manager_id")] user user)
        {
            if (ModelState.IsValid)
            {
                db.user.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.manager_id = new SelectList(db.user, "id", "Firstname", user.manager_id);
            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.manager_id = new SelectList(db.user, "id", "Firstname", user.manager_id);
            return View(user);
        }

        // POST: users/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Firstname,LastName,Phone,cin,grade,login,mail,password,rating,role,salary,speciality,manager_id")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.manager_id = new SelectList(db.user, "id", "Firstname", user.manager_id);
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.user.Find(id);
            db.user.Remove(user);
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


        ////logiiiiiiiiiiiiiiin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "password,login")] user user)
        {
            if (ModelState.IsValid)
            {
                UserService us = new UserService();
                user user3 = us.FindRoleByName(user.login);
                if (user.password == user3.password)
                {
                    if (user3.role == "Manager")
                    {
                        return RedirectToAction("loginAdmin");
                    }
                    else if (user3.role == "Employee")
                    {
                        return RedirectToAction("loginClient");
                    }
                    else
                    {
                        return View(user);
                    }
                }


            }

            return View(user);
        }


        public ActionResult loginAdmin()
        {



            return RedirectToAction("Index", "settings");

        }
        public ActionResult loginClient()
        {



            return RedirectToAction("Index", "tickets");

        }
    }
}
