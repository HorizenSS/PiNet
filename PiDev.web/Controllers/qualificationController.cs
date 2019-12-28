using Newtonsoft.Json;
using PiDev.Domain;
using PiDev.Service;
using PiDev.web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helper;

namespace PiDev.web.Controllers
{
    public class qualificationController : Controller
    {
        jobOfferService Pservice = null;
        qualificationService qualificationservice = null;
        public qualificationController()
        {
            qualificationservice = new qualificationService();
            Pservice = new jobOfferService();
        }
        // GET: qualification
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Allqualifications(int idJobOffer)
        {

            var idP = Session["idJobOffer"] as List<int>;

            if (idP == null)
            {
                idP = new List<int>();
            }

            Session["idJobOffer"] = idP;
            var x = qualificationservice.DisplayqualificationsByjobOffer(idJobOffer);
            idP.Add(idJobOffer);

            return View(x);
        }

        // GET: ReservationEvent/Create
        public ActionResult Create()
        {
           // var Job = Tservice.GetMany();
           // ViewBag.category = new SelectList(categories, "IdCategory", "Name");






            var idP = Session["idJobOffer"] as List<int>;
            List<string> ListState = new List<string> { "ToLearn", "Learning", "Mastered" };
            ViewBag.x = ListState.ToSelectItem();

            qualificationVM qualificationVM = new qualificationVM();
            qualificationVM.jobname = qualificationservice.FindNamejobOfferById(idP.First());

            return View(qualificationVM);
        }


        // POST: ReservationEvent/Create
        [HttpPost]
        public ActionResult Create(qualificationVM qualificationVM)
        {
            var idP = Session["idJobOffer"] as List<int>;
            qualificationVM.idJobOffer = idP.First();

            qualification qualificationToAdd = new qualification
            {
                Description = qualificationVM.Description,
                idJobOffer = qualificationVM.idJobOffer,
                cin = qualificationVM.cin,
                DeadLine = qualificationVM.DeadLine,
                StartDate = qualificationVM.StartDate,
                state = qualificationVM.state
            };



            qualificationservice.Add(qualificationToAdd);
            qualificationservice.Commit();
            qualificationservice.Dispose();


            return RedirectToAction("Allqualifications", new { idJobOffer = idP.First() });
        }

        //GET: ReservationEvent/Edit/5
        public ActionResult Edit(int idJobOffer, string description, int idUser)
        {
            qualification qualificationToEdit = qualificationservice.FindqualificationByPk(description);
            //qualificationVM qualificationVM = new qualificationVM
            //{
            //    Description = qualificationToEdit.Description,
            //    idJobOffer = qualificationToEdit.idJobOffer,
            //    cin = qualificationToEdit.cin,
            //    DeadLine = qualificationToEdit.DeadLine,
            //    StartDate = qualificationToEdit.StartDate,
            //    state = qualificationToEdit.state

            //};

            return View(qualificationToEdit);

        }
        // POST: ReservationEvent/Edit/5
        [HttpPost]
        public ActionResult Edit(int idJobOffer, string description, int idUser, qualification qualification)
        {
            var idP = Session["idJobOffer"] as List<int>;
            //qualification qualificationToEdit = qualificationservice.FindqualificationByPk(qualification.Description);
            qualification qualificationToEdit = new qualification { Description = qualification.Description, idJobOffer = qualification.idJobOffer, DeadLine = qualification.DeadLine, StartDate = qualification.StartDate, state = qualification.state, cin = qualification.cin };

            try
            {
                qualificationservice.Update(qualificationToEdit);
                //UpdateModel(qualificationToEdit);


                qualificationservice.Commit();
                return RedirectToAction("Allqualifications", new { idJobOffer = idP.First() });


            }
            catch
            {


                return RedirectToAction("Allqualifications", new { idJobOffer = idP.First() });
            }


        }


        // GET: ReservationEvent/Delete/5
        public ActionResult Delete(string description)
        {
            qualification qualificationToDelete = qualificationservice.FindqualificationByPk(description);
            if (qualificationToDelete == null)
            {
                return HttpNotFound();
            }
            qualificationVM qualificationVM = new qualificationVM
            {
                Description = qualificationToDelete.Description,
                idJobOffer = qualificationToDelete.idJobOffer,
                cin = qualificationToDelete.cin,
                DeadLine = qualificationToDelete.DeadLine,
                StartDate = qualificationToDelete.StartDate,
                state = qualificationToDelete.state


            };

            return View(qualificationToDelete);
        }

        // POST: ReservationEvent/Delete/5
        [HttpPost]
        public ActionResult Delete(string description, qualificationVM qualificationVM)
        {
            var idP = Session["idJobOffer"] as List<int>;
            qualification qualificationToDelete = qualificationservice.FindqualificationByPk(description);
            qualificationservice.Deletequalification(qualificationToDelete.Description);
            qualificationservice.Commit();
            qualificationservice.Dispose();


            return RedirectToAction("Allqualifications", new { idJobOffer = idP.First() });

        }

        public ActionResult qualificationStat(int idJobOffer)
        {

            string jobname = qualificationservice.FindNamejobOfferById(idJobOffer);
            string DeadlineInfo = qualificationservice.jobOfferDeadlineVerification(idJobOffer);
            // prepare a 2d array in c#
            ArrayList header = new ArrayList { "qualification State", "Number" };
            ArrayList data1 = new ArrayList { "Doing", qualificationservice.numberOfAccomplishqualificationsByjobOffer(idJobOffer) };
            ArrayList data2 = new ArrayList { "Done", qualificationservice.numberOfInProgressqualificationsByjobOffer(idJobOffer) };
            ArrayList data3 = new ArrayList { "To Do", qualificationservice.numberOfNotStartedqualificationsByjobOffer(idJobOffer) };
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


    }
}