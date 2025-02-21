using EduManage.Data;
using EduManage.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.Controllers
{
    [MyCustomExceptionFilter]
    public class InstructorController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
          
            var insList = context.Instructors.Where(s=>s.Status==true)
                .Include(d => d.Courses).ToList();
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
                instructor.Status = true;

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
            var instructor = context.Instructors.Include(c => c.Courses).FirstOrDefault(d => d.Id == Id);


            if (instructor == null)
                return NotFound();

            return View(instructor);

        }
        public IActionResult Edit(int? Id)
        {


            if (Id == null)
                return BadRequest();
            var instructor = context.Instructors.Include(c => c.Courses).FirstOrDefault(d => d.Id == Id);
            if (instructor == null)
                return NotFound();
            //ViewBag.courses = context.Courses.ToList();
            return View(instructor);

        }
        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                instructor.Status = true;
                context.Instructors.Update(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.courses = context.Courses.ToList();
            return View(instructor);
        }

        public IActionResult Delete(int? Id)
        {
            var instructor = context.Instructors.FirstOrDefault(d => d.Id == Id);
          
            if (instructor != null)
            {
                instructor.Status = false;
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }




    }
}
