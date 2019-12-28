
using PiDev.Domain;
using Newtonsoft.Json;
using PiDev.Service;
using PiDev.Service.IServices;
using PiDev.web.Models;
using Presentation.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Controllers
{
    public class SkillController : Controller
    {
         ISkillService skillService;
       // IResourceService rs;
        public SkillController()
        {
            skillService = new SkillService();
           // rs = new ResourceService();
        }

        // GET: Skill
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // HttpResponseMessage response;
            
            
            HttpResponseMessage response = Client.GetAsync("PiDev-web/rest/skills").Result;
            if(response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<SkillVM>>().Result;Console.WriteLine("ok");
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
           /*
            /* var categories = skillService.GetMany().Select(c => c.category).Distinct();
             List<SkillVM> skills = new List<SkillVM>();
             IEnumerable<SkillVM> resourceSkills;
             var skillstocast = skillService.GetMany();
             foreach (var s in skillstocast)
             {
                 skills.Add(new SkillVM { category=s.category,name=s.name,skillId=s.skillId,count=0});
             }
            var resources = rs.GetMany().Where(r => r.resumeId > 0);
             foreach (var resource in resources)
             {
                 response = Client.GetAsync("map-web/rest/resources/skills/" +resource.userId).Result;
                 if (response.IsSuccessStatusCode)
                 {
                     resourceSkills = response.Content.ReadAsAsync<IEnumerable<SkillVM>>().Result;
                     foreach (var s in skills)
                     {
                         if (resourceSkills.Contains(resourceSkills.Where(r=>r.skillId == s.skillId).FirstOrDefault()))
                         {
                             s.count += 1;
                         }
                     }
                 }
             }
             ViewBag.result = skills;
             ViewBag.categories = categories;
  */
           // return View();
           
        }

        // GET: Skill/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Skill/Create
       public ActionResult Create()
        {
            IEnumerable<String> categories = skillService.GetMany().Select(c => c.category).Distinct();
            ViewBag.result = categories;
            return View("Create");
        }

      // POST: Skill/Create
        [HttpPost]
        public ActionResult Create(SkillVM sk)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.PostAsJsonAsync<SkillVM>("PiDev-web/rest/skills", sk).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

       // GET: Skill/Edit/5
         public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(SkillVM sk)
        {
            HttpClient Client = new HttpClient();
           
            var response1 = Client.PutAsJsonAsync<SkillVM>("http://localhost:9080/PiDev-web/rest/skills/", sk).ContinueWith((putTask) => putTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("index");
        }


        
        // POST: Skill/Edit/5
       /* [HttpPost]
        public ActionResult foo(SkillVM sk, FormCollection collection)
        {
         sk.skillId =Int32.Parse(Request.Form["skillId"]);
            sk.category= Request.Form["category"].ToString();
            sk.name=Request.Form["name"].ToString();

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.PutAsJsonAsync<SkillVM>("PiDev-web/rest/skills", sk).ContinueWith((putTask) => putTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }*/
        
        // GET: Skill/Delete/5
        public ActionResult Delete(int id)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:9080/PiDev-web/rest/skills/" +"?id="+id.ToString()).Result;

            return RedirectToAction("Index");
        }

        // POST: Skill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
