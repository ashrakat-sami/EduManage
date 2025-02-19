
using EduManage.Data;

namespace EduManage.Controllers
{
    //[Route("c/{action=index}/{id:int?}")] 
    public class StudentController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var stdList = context.Students.Include(d => d.Department).ToList();
            return View(stdList);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.depts = context.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depts = context.Departments.ToList();
            return View(student);

        }

        public IActionResult Details(int? Id)
        {

            if (Id == null)
                return BadRequest();
            var student = context.Students.Include(s=>s.StudentCourses).ThenInclude(c=>c.Course)
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


        public IActionResult CheckEmailExistance(string Email,int Id)
        {
           var res= context.Students.FirstOrDefault(s => s.Email == Email);
            if (res != null && res.Id !=Id)    
                return Json(false);
            
            return Json(true);
        }
    }
}
