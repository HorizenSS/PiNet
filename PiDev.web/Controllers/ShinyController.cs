using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Controllers
{
    public class ShinyController : Controller
    {
        // GET: Shiny
        public ActionResult Index()
        {
            ViewBag.IFrameSrc = " https://advyteamexpense.shinyapps.io/PIDEVDATAMINIG/";
            return View();
        }

        // GET: Shiny/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shiny/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shiny/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shiny/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shiny/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shiny/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shiny/Delete/5
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
