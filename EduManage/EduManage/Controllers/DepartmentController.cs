using EduManage.Data;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var deptList = context.Departments.ToList();
            return View(deptList);
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
                context.Departments.Add(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }



        public IActionResult Details(int? Id)
        {
            

            if (Id == null)
                return BadRequest();
            var department = context.Departments.Include(c=>c.Courses)
            .FirstOrDefault(d => d.Id == Id);
            if (department == null)
                return NotFound();

            return View(department);

        }
        public IActionResult Edit(int? Id)
        {


            if (Id == null)
                return BadRequest();
            var department = context.Departments
            .FirstOrDefault(d => d.Id == Id);
            if (department == null)
                return NotFound();

            return View(department);

        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Update(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        public IActionResult Delete(int? Id)
        {
            var students = context.Students.Where(d => d.DeptId == Id).ToList();
            if (students.Any())
                return Content("Cannot delete this department");
            else
            {

                if (Id == null)
                    return BadRequest();
                var department = context.Departments.FirstOrDefault(d => d.Id == Id);
                if (department == null)
                    return NotFound();

                return View(department);
            }

        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? Id)
        {
            var department = context.Departments.FirstOrDefault(d => d.Id == Id);
            if (ModelState.IsValid)
            {

                context.Departments.Remove(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depts = context.Departments.ToList();
            return View(department);
        }
    }
}
