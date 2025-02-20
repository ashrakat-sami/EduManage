
using EduManage.Data;
using EduManage.Services;

namespace EduManage.Controllers
{
    //[Route("c/{action=index}/{id:int?}")] 
    public class StudentController : Controller
    {
        private IStudent service;
        private IDepartment dService;

        public StudentController(IStudent service,IDepartment dService)
        {
            this.service = service;
            this.dService = dService;
        }

        public IActionResult Index()
        {
            var stdList = service.GetAll();
            return View(stdList);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.depts = dService.GetAll();
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                //context.Students.Add(student);
                //context.SaveChanges();
                service.Create(student);
                return RedirectToAction("Index");
            }
              ViewBag.depts = dService.GetAll();
            return View(student);

        }

        public IActionResult Details(int? Id)
        {

            if (Id == null)
                return BadRequest();
            //var student = context.Students.Include(s=>s.StudentCourses).ThenInclude(c=>c.Course)
            //    .Include(d => d.Department)
            //.FirstOrDefault(d => d.Id == Id);
            var student = service.GetById(Id.Value);
            if (student == null)
                return NotFound();

            return View(student);

        }
        public IActionResult Edit(int? Id)
        {
            

            if (Id == null)
                return BadRequest();
            //var student = context.Students.Include(d => d.Department).FirstOrDefault(d => d.Id == Id);
            var student = service.GetById(Id.Value);
                
            if (student == null)
                return NotFound();
            ViewBag.depts = dService.GetAll();
            return View(student);

        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                //context.Students.Update(student);
                //context.SaveChanges();
                service.Update(student);
                return RedirectToAction("Index");
            }
            //ViewBag.depts = context.Departments.ToList();
            ViewBag.depts = dService.GetAll();

            return View(student);
        }

        public IActionResult Delete(int? Id)
        {
            service.Delete(Id.Value);
            return RedirectToAction("Index");
        }


        public IActionResult CheckEmailExistance(string Email, int Id)
        {
            //var res = context.Students.FirstOrDefault(s => s.Email == Email);
      
            if (service.CheckEmailExistance(Email,Id))
                return Json(false);

            return Json(true);
        }
    }
}
