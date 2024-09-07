using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service._Interfaces;
using Company.Service._Services.Department.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            //TempData.Keep("TextTempMessage");
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create() {

            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentDpo dept) {

            if (ModelState.IsValid)
            {
                _departmentService.Add(dept);
                //TempData["TextTempMessage"] = "Hello From Employee Index (TempData)";
                return RedirectToAction("Index");
            }
            else { 
            return View(dept);
            }

        }
        public IActionResult Details(int? id,string viewName = "Details")
        { 
            var department = _departmentService.GetById(id);
            if (department is null) {
            return RedirectToAction("NotFoundPage",null,"Home"); 
            }
            return View(viewName,department);        
        }
        [HttpGet]
        public IActionResult Update(int? id) {
            return Details(id,"Update");
        }
        [HttpPost]
        public IActionResult Update(int? id, DepartmentDpo department) {
            if (department.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");

            _departmentService.Update(department);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            var department = _departmentService.GetById(id);
            if (department is null)
            {
                return RedirectToAction("NotFoundPage", null, "Home");
            }
            _departmentService.Delete(department);
            return RedirectToAction("Index");

        }
    }
}
