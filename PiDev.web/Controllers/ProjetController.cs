using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PiDev.Domain.Entities;
namespace PiDev.web.Controllers
{
    public class ProjetController : Controller
    {
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


    } }
