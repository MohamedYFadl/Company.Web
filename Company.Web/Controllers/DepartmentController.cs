using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service._Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create() {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept) {

            _departmentService.Add(dept);
            return RedirectToAction("Index");
        }
    }
}
