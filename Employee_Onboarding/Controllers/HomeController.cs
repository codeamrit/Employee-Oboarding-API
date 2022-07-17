using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using WebApplication2.Models;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Employee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveEmployee(EmployeeModel emp)
        {
            var client = new RestClient("http://localhost:5019/api");
            //.Timeout = -1;
            var request = new RestRequest("/employee/SaveEmployee", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(emp);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return View("Employee");
        }

        [HttpGet]
        public IActionResult DeleteEmployee(string EmpId)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = EmpId;
            var client = new RestClient("http://localhost:5019/api");
            //.Timeout = -1;
            var request = new RestRequest("/employee/DeleteEmployee", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(emp);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return RedirectToAction("EmployeeList", "Home");
        }


        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeModel emp)
        {
            var client = new RestClient("http://localhost:5019/api");
            //.Timeout = -1;
            var request = new RestRequest("/employee/UpdateEmployee", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(emp);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return View("Employee");
        }
        public IActionResult GetEmployeeDetail(string EmpId)
        {
            var client = new RestClient("http://localhost:5019/api");
            //.Timeout = -1;
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = EmpId;

            var request = new RestRequest("/employee/GetEmployee", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(emp);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            List<EmployeeModel> lstemp = JsonConvert.DeserializeObject<List<EmployeeModel>>(response.Content);
            //Console.WriteLine(response.Content);
            return View("UpdateEmployee",lstemp.FirstOrDefault());
        }

        public IActionResult EmployeeList()
        {
            var client = new RestClient("http://localhost:5019/api");
            //.Timeout = -1;
            EmployeeModel emp = new EmployeeModel();

            var request = new RestRequest("/employee/GetEmployee", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(emp);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            List<EmployeeModel> lstemp = JsonConvert.DeserializeObject<List<EmployeeModel>>(response.Content);
            //Console.WriteLine(response.Content);
            return View(lstemp);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}