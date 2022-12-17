using BasicCRUDText.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicCRUDText.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly StudentDbContext _context;
        public DepartmentController(StudentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Department> departments = _context.Departments.ToList();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Delete(int DepId)
        {
            Department department = _context.Departments.FirstOrDefault(department => department.DepId == DepId);
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(Department department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int DepId)
        {
            Department department = _context.Departments.Find(DepId);
            return View(department);
        }
        [HttpPost]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}
