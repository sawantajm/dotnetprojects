using System.Text;
using System.Text.Json.Serialization;
using CRUDAPPUsingWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUDAPPUsingWebApi.Controllers
{
    public class EmployeeController : Controller
    {
        private string url = "http://localhost:5037/api/EmployeeAPI/";
        private HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode) { 
                string ressult= response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Employee>>(ressult);

                if (data != null) 
                {
                    employees = data;
                }

            }
            return View(employees);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            string data = JsonConvert.SerializeObject(emp);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/Json");
            HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["Insert_Data"] = "Data Inserted Sucseefully";
                return RedirectToAction("Index", "Employee");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = new Employee();
            HttpResponseMessage respose = client.GetAsync(url +"id?id=" + id ).Result;
            if (respose.IsSuccessStatusCode)
            {
                string ressult = respose.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Employee>(ressult);

                if (data != null)
                {
                    employee = data;
                }

            }
            return View(employee);
        }

        [HttpPost]
            public IActionResult Edit(int id, Employee emp) 
        {
            string data = JsonConvert.SerializeObject(emp);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/Json");
            HttpResponseMessage response = client.PutAsync(url + "id?id=" + id, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Update_Data"] = "Data Update Sucseefully";
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee employee = new Employee();
            HttpResponseMessage respose = client.GetAsync(url + "id?id=" + id).Result;
            if (respose.IsSuccessStatusCode)
            {
                string ressult = respose.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Employee>(ressult);

                if (data != null)
                {
                    employee = data;
                }

            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee employee = new Employee();
            HttpResponseMessage respose = client.GetAsync(url + "id?id=" + id).Result;
            if (respose.IsSuccessStatusCode)
            {
                string ressult = respose.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Employee>(ressult);

                if (data != null)
                {
                    employee = data;
                }

            }
            return View(employee);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteById(int id)
        {
            Employee employee = new Employee();
            HttpResponseMessage respose = client.DeleteAsync(url + "id?id=" + id).Result;
            if (respose.IsSuccessStatusCode)
            {

                TempData["Delete_Data"] = "Data Deleted Sucseefully";
                return RedirectToAction("Index", "Employee");
                string.Concat();
            }
            return View();
        }

    }
}
