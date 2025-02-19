using EduManage.Data;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.Controllers
{
    public class InstructorController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var insList = context.Instructors.Include(d => d.Courses).ToList();
            return View(insList);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.crs = context.Courses.ToList();
            ViewBag.depts = context.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depts = context.Departments.ToList();
            ViewBag.crs = context.Courses.ToList();
            return View(instructor);

        }

        public IActionResult Details(int? Id)
        {

            if (Id == null)
                return BadRequest();
            var student = context.Students.Include(s => s.StudentCourses).ThenInclude(c => c.Course)
                .Include(d => d.Department)
            .FirstOrDefault(d => d.Id == Id);
            if (student == null)
                return NotFound();

            return View(student);

        }
        public IActionResult Edit(int? Id)
        {


            if (Id == null)
                return BadRequest();
            var student = context.Students.Include(d => d.Department)
                .FirstOrDefault(d => d.Id == Id);
            if (student == null)
                return NotFound();
            ViewBag.depts = context.Departments.ToList();
            return View(student);

        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depts = context.Departments.ToList();
            return View(student);
        }

        public IActionResult Delete(int? Id)
        {


            if (Id == null)
                return BadRequest();
            var student = context.Students.Include(d => d.Department).FirstOrDefault(d => d.Id == Id);
            if (student == null)
                return NotFound();

            return View(student);

        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? Id)
        {
            var student = context.Students.Include(d => d.Department).FirstOrDefault(d => d.Id == Id);
            if (ModelState.IsValid)
            {

                context.Students.Remove(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depts = context.Departments.ToList();
            return View(student);
        }


        
    }
}
