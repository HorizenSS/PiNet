using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PiDev.Service;
using PiDev.Domain;
using System.IO;
using Rotativa;

namespace PiDev.web.Controllers
{
    public class jobOffersController : Controller, IDisposable
    {

        jobOfferService Pservice = null;
        qualificationService Tservice = null;

        public jobOffersController()
        {
            Pservice = new jobOfferService();
            Tservice = new qualificationService();
        }
        // GET: jobOffer
        public ActionResult AlljobOffer()
        {
            var jobOffer = Pservice.GetMany();

            List<jobOffer> pr = new List<jobOffer>();
            foreach (var item in jobOffer)
            {
                pr.Add(
                    new jobOffer
                    {
                        IdJobOffer = item.IdJobOffer,
                        Description = item.Description,
                        Name = item.Name,
                        salary = item.salary,
                        EndDate = item.EndDate,
                        StartDate = item.StartDate,
                        DocumentsUrl = item.DocumentsUrl

                    });

            }


            return View(pr);
        }




        [HttpPost]

        public ActionResult AlljobOffer(String search)
        {
            var jobOffers = Pservice.GetMany(p => p.Name == search);
            List<jobOffer> pr = new List<jobOffer>();
            
            foreach (var item in jobOffers)
            {
                pr.Add(
                    new jobOffer
                    {
                        IdJobOffer = item.IdJobOffer,
                        Description = item.Description,
                        Name = item.Name,
                        salary = item.salary,
                       
                        EndDate = item.EndDate,
                        StartDate = item.StartDate,
                        DocumentsUrl = item.DocumentsUrl

                    });


            }


            return View(pr);

        }


        public ActionResult Index()
        {

            return View();
        }




        // GET: jobOffer/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobOffer p = Pservice.GetById(id);




            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);

        }

        // GET: jobOffer/Create
        public ActionResult Create()
        {
           

           
          
           
   
            return View();
        }

        // POST: jobOffer/Create
        [HttpPost]
        public ActionResult Create(jobOffer p, HttpPostedFileBase doc)
        {

            if (!ModelState.IsValid || doc == null || doc.ContentLength == 0)
            {
                RedirectToAction("Create");
            }

            //if (doc != null  )
            //{
            //    //p.DocumentsUrl = doc.FileName;
            //    jobOffer pr = new jobOffer
            //    {
            //        IdJobOffer = p.IdJobOffer,
            //        Description = p.Description,
            //        Name = p.Name,
            //        Priority = p.Priority,
            //        Type = p.Type,
            //        EndDate = p.EndDate,
            //        StartDate = p.StartDate,
            //        DocumentsUrl = p.DocumentsUrl ,
            //        Category_IdCategory = p.Category_IdCategory ,
            //        id_client = p.id_client ,
            //        id_team = p.id_team

            //    };
            //    Pservice.Add(pr);
            //    Pservice.commit();
            //    Pservice.Dispose();
            //    // Sauvgarde de l'image

            //    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), doc.FileName);
            //    doc.SaveAs(path);
            //    return RedirectToAction("Index");

            //}
            //return View();

            if (!ModelState.IsValid)
            {
                return Create();
            }


            p.DocumentsUrl = doc.FileName;
            jobOffer pr = new jobOffer
            {
                IdJobOffer = p.IdJobOffer,
                Description = p.Description,
                Name = p.Name,
                salary = p.salary,
              
                EndDate = p.EndDate,
                StartDate = p.StartDate,
                DocumentsUrl = p.DocumentsUrl,
               

            };
            Pservice.Add(pr);
            Pservice.Commit();
            Pservice.Dispose();
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), doc.FileName);
            doc.SaveAs(path);

            return RedirectToAction("Index");

        }

        // GET: jobOffer/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobOffer p = Pservice.GetById(id);

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: jobOffer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, jobOffer p)
        {
            if (!ModelState.IsValid)
            {
                return EditDetails();
            }

            if (ModelState.IsValid)
            {

                Pservice.Update(p);
                Pservice.Commit();
                Pservice.Dispose();

                return RedirectToAction("Index");
            }
            return View(p);
        }

        // GET: jobOffer/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobOffer p = Pservice.GetById(id);

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: jobOffer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, jobOffer p)
        {
            jobOffer j = Pservice.GetById(id);
            Pservice.Delete(j);
            Pservice.Commit();
            Pservice.Dispose();

            return RedirectToAction("Index");

        }
        public ActionResult EditDetails()
        {
         
           
            return View();

        }


        public ActionResult UploadFile(HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Files/" + file.FileName); // location
                file.SaveAs(path);
                @ViewBag.Path = path;




            }
            return View();



        }

        public ActionResult ExportPDF()


        {


            return new ActionAsPdf("index")
            {

                FileName = Server.MapPath("~/Content/Files/products.pdf")
            };
        }
   


        public ActionResult ActiveList()
        {
            var jobOffer = Pservice.ActivejobOffer();

            List<jobOffer> pr = new List<jobOffer>();
            foreach (var item in jobOffer)
            {
                pr.Add(
                    new jobOffer
                    {
                        IdJobOffer = item.IdJobOffer,
                        Description = item.Description,
                        Name = item.Name,
                        salary = item.salary,
                        
                        EndDate = item.EndDate,
                        StartDate = item.StartDate,
                        DocumentsUrl = item.DocumentsUrl

                    });

            }


            return View(pr);
        }

        public ActionResult PassedList()
        {
            var jobOffer = Pservice.PassedjobOffer();

            List<jobOffer> pr = new List<jobOffer>();
            foreach (var item in jobOffer)
            {
                pr.Add(
                    new jobOffer
                    {
                        IdJobOffer = item.IdJobOffer,
                        Description = item.Description,
                        Name = item.Name,
                        salary = item.salary,
                     
                        EndDate = item.EndDate,
                        StartDate = item.StartDate,
                        DocumentsUrl = item.DocumentsUrl

                    });

            }


            return View(pr);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Pservice.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}

