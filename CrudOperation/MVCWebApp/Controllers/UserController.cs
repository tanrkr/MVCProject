using MVCWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        HttpClient client;
        Uri BaseAddress = new Uri("http://localhost:44393/api");
        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = BaseAddress;
        }
        public ActionResult Index()
        {
            List<UserViewModel> UserModel = new List<UserViewModel>();
            HttpResponseMessage response = client.GetAsync(BaseAddress+"/Employee").Result; 
            if(response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;    
                UserModel= JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }
            return View(UserModel);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        // GET: User/Create
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            String data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data,Encoding.UTF8, "application/Json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress+"/Employee/Post",content).Result;
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            UserViewModel model= new UserViewModel();
            HttpResponseMessage response = client.GetAsync(BaseAddress+"/Employee/" + id).Result;
            if(response.IsSuccessStatusCode)
            {
                String data=response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<UserViewModel>(data);
            }
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel model)
        {
           
            String Data= JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(Data,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Employee/" + id, content).Result;
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
               
                return View("Edit");
            
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
             UserViewModel model = new UserViewModel();
            HttpResponseMessage response = client.GetAsync(BaseAddress + "/Employee/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<UserViewModel>(data);
            }
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserViewModel model)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Employee/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}
