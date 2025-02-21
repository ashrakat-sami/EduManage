using EduManage.Data;
using EduManage.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.Controllers
{
    public class DepartmentController : Controller
    {
       // ApplicationDbContext db= new ApplicationDbContext();
        private IDepartment dservice;
        public DepartmentController(IDepartment _dservice)
        {
            dservice = _dservice;
        }
        public IActionResult Index()
        {
            //var deptList = context.Departments.ToList();
            var deptList = dservice.GetAll();
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
                //context.Departments.Add(department);
                //context.SaveChanges();
                dservice.Create(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }



        public IActionResult Details(int? Id)
        {
            

            if (Id == null)
                return BadRequest();
            // var department = context.Departments.Include(c=>c.Courses) .FirstOrDefault(d => d.Id == Id);
            var department= dservice.GetById(Id.Value);

            if (department == null)
                return NotFound();

            return View(department);

        }
        public IActionResult Edit(int? Id)
        {


            if (Id == null)
                return BadRequest();
            //var department = context.Departments
            //.FirstOrDefault(d => d.Id == Id);
            var department = dservice.GetById(Id.Value);

            if (department == null)
                return NotFound();

            return View(department);

        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                //context.Departments.Update(department);
                //context.SaveChanges();
                dservice.Update(department); 
                return RedirectToAction("Index");
            }

            return View(department);
        }

        #region Old delete action
        //public IActionResult Delete(int? Id)
        //{
        //    var students = db.Students.Where(d => d.DeptId == Id).ToList();
        //    if (students.Any())
        //        return Content("Cannot delete this department");
        //    else
        //    {

        //        if (Id == null)
        //            return BadRequest();
        //        // var department = context.Departments.FirstOrDefault(d => d.Id == Id);
        //        var department = context.GetById(Id.Value);

        //        if (department == null)
        //            return NotFound();

        //        return View(department);
        //    }

        //}
        //[HttpPost]
        //[ActionName("Delete")]
        //public IActionResult ConfirmDelete(int? Id)
        //{
        //    //var department = context.Departments.FirstOrDefault(d => d.Id == Id);
        //    var department = context.GetById(Id.Value);

        //    if (ModelState.IsValid)
        //    {

        //        //context.Departments.Remove(department);
        //        //context.SaveChanges();
        //        context.Delete(Id.Value);
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.depts = context.Departments.ToList();
        //    ViewBag.depts = context.GetAll();
        //    return View(department);
        //}
        #endregion

        public IActionResult Delete(int? Id)
        {
            dservice.Delete(Id.Value);
            return RedirectToAction("Index");
        }

    }
}
