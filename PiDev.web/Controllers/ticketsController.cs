using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PiDev.Data;
using PiDev.Domain.Entities;
using PiDev.web.Models;

namespace PiDev.web.Controllers
{
    public class ticketsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tickets
        // GET: Projet
        public ActionResult Index()
        {

            HttpClient Client = new System.Net.Http.HttpClient();
            //Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/PiDev-web/ws/tickets").Result;
            if (response.IsSuccessStatusCode)

            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ticket>>().Result;

            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }
        /*

                [HttpGet]
                public ActionResult Create()
                {
                    return View("Create");

                }

                [HttpPost]
                public ActionResult Create(ticket t)
                {

                    // TODO: Add insert logic here
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:9080");
                    client.PostAsJsonAsync<ticket>("PiDev-web/ws/tic", t).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                        return RedirectToAction("Index");


                }
                */
        /*
[HttpGet]
public ActionResult Create()
{
    return View("Create");

}


[HttpPost]
public ActionResult Create(ticket p)
{
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:9080/PiDev-web");

    // TODO: Add insert logic here
    client.PostAsJsonAsync<ticket>("ws/tic", p)
                .ContinueWith((postTask) => postTask.Result.ReasonPhrase.Equals("Created"));
    return RedirectToAction("Index");

}
*/
        public ActionResult Create()
        {
            return View(new Tick());

        }

        [HttpPost]
        public ActionResult Create(Tick t)
        {
         
            try
             { 
            // TODO: Add insert logic here
            HttpClient Client = new System.Net.Http.HttpClient();
                //Client.BaseAddress = new Uri("http://localhost:9080");
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                t.employee = null;
                HttpResponseMessage response = Client.PostAsJsonAsync<Tick>("http://localhost:9080/PiDev-web/ws/tic", t).Result;
               


                return RedirectToAction("Index");
         }
            catch
            {
                return View();
            }
        }

        /*
        public ActionResult Delete(int id)
        {

            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));



            HttpResponseMessage response = client.DeleteAsync("http://localhost:9080/PiDev-web/ws/tic/" + id.ToString()).Result;
            TempData["SM"] = "supprimer avec succes";
            return RedirectToAction("Index");


        }
        */



        //Partie Controller

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/Project/" + id).Result;
            Domain.Entities.ticket project = new ticket();
            if (response.IsSuccessStatusCode)
            {

                project = response.Content.ReadAsAsync<ticket>().Result;

            }
            else
            {
                ViewBag.project = "erreur";
            }

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");

                // TODO: Add insert logic here
                client.DeleteAsync("ws/tic/" + id)
                        .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }





}

