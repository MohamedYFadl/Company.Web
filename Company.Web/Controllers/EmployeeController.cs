using Company.Data.Entities;
using Company.Service._Interfaces;
using Company.Service._Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAll();
            return View(Employees);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {

            _employeeService.Add(employee);
            if (ModelState.IsValid)
            {
                _employeeService.Add(employee);
                return RedirectToAction("Index","Employee",null);
            }
            else
            {
                return View(employee);
            }

        }
        public IActionResult Details(int? id, string viewName = "Details")
        {
            var employee = _employeeService.GetById(id);
            if (employee is null)
            {
                return RedirectToAction("NotFoundPage","Home",null);
            }
            return View(viewName, employee);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }
        [HttpPost]
        public IActionResult Update(int? id, Employee employee)
        {
            if (employee.Id != id.Value)
                return RedirectToAction("NotFoundPage","Home",null);

            _employeeService.Update(employee);
            return RedirectToAction("Index",null,"Employee");
        }

        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee is null)
            {
                return RedirectToAction("NotFoundPage","Home",null);
            }
            _employeeService.Delete(employee);
            return RedirectToAction("Index","Employee",null);

        }
    }
}
