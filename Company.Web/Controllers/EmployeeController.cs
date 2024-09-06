﻿using Company.Data.Entities;
using Company.Service._Interfaces;
using Company.Service._Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public IActionResult Index(string SearchInput)
        {
            ViewBag.Message = "Hello From Employee Index (ViewBag)";
            ViewData["TextMessage"] = "Hello From Employee Index (ViewData)";
            TempData["TextTempMessage"] = "Hello From Employee Index (TempData)";

            IEnumerable<Employee> employees = new List<Employee>();
            if (string.IsNullOrEmpty(SearchInput))
                employees = _employeeService.GetAll();


            else
                employees = _employeeService.GetEmployeeByName(SearchInput);
                
            return View(employees);

            
        }
        public IActionResult Add()
        {
            var department = _departmentService.GetAll();
            return View(department);
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
