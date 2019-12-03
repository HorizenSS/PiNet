using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using PiDev.Domain.Entities;
using PiDev.web.Models;

namespace PiDev.web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {

            HttpClient Client = new System.Net.Http.HttpClient();
            //Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/PiDev-web/rest/test").Result;
            
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Test>>().Result;

            return View();
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(Test t)
        {
            try
            {
                // TODO: Add insert logic here
                HttpClient Client = new System.Net.Http.HttpClient();
                //Client.BaseAddress = new Uri("http://localhost:9080");
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = Client.PostAsJsonAsync<Test>("http://localhost:9080/PiDev-web/rest/test/addtest", t).Result;
                TempData["SM"] = "Ajout avec succes";


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {

            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/PiDev-web/rest/test/"+id.ToString()).Result;
            Test t = response.Content.ReadAsAsync<Test>().Result;
            
            return View(t);
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(Test t)
        {
            try
            {
                // TODO: Add update logic here
                HttpClient Client = new HttpClient();
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                int i = t.formation.idFormation;
                t.formation = null;
                HttpResponseMessage response = Client.PutAsJsonAsync("http://localhost:9080/PiDev-web/rest/test/" + i.ToString(), t).Result;
                TempData["SM"] = "modifier avec succes";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {

             HttpClient client = new HttpClient();
             //client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
             client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));



             HttpResponseMessage response = client.DeleteAsync("http://localhost:9080/PiDev-web/rest/test/delT/" + id.ToString()).Result;
            TempData["SM"] = "supprimer avec succes";
            return RedirectToAction("Index");

            
        }

        // POST: Test/Delete/5
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


        public ActionResult AddFormation(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("http://localhost:9080/PiDev-web/rest/formation/").Result;
          
            List<formation> listF = response.Content.ReadAsAsync<List<formation>>().Result;
            ViewBag.formation = listF;
            TForF t = new TForF() { idTest = id };
            return View(t);
        }

        [HttpPost]
        public ActionResult AddFormation(TForF testForFormation)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PutAsync("http://localhost:9080/PiDev-web/rest/test/addFormation/"+testForFormation.idTest.ToString()+"/"+testForFormation.idFormation.ToString(),null).Result;

            TempData["SM"] = "Success";
            return RedirectToAction("Index");
        }


    }
}
