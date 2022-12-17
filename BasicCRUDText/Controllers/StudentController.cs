using BasicCRUDText.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicCRUDText.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> students = _context.Students.Include(x => x.Department);
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Department> departments = _context.Departments.ToList();
            ViewBag.Dept = departments;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Department> departments = _context.Departments.ToList();
            ViewBag.Dept = departments;
            return View();
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            List<Department> departments = _context.Departments.ToList();
            ViewBag.Dept = departments;
            Student student = _context.Students.Find(Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Department> departments = _context.Departments.ToList();
            ViewBag.Dept = departments;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            List<Department> departments = _context.Departments.ToList();
            ViewBag.Dept = departments;
            Student student = _context.Students.Find(Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
