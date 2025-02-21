
using EduManage.Data;
using EduManage.Models;

namespace EduManage.Services
{
    public class StudentService : IStudent, IEmailCheck
    {
         ApplicationDbContext context=new ApplicationDbContext();

        //public StudentService(ApplicationDbContext context)
        //{
        //    this.context = context;
        //}

        public bool CheckEmailExistance(string Email, int Id)
        {
            var res = context.Students.AsNoTracking().FirstOrDefault(s => s.Email == Email);
            if (res != null && res.Id != Id) //that means the email is already exist with different person
                return true;
            return false;

            
        }

        public void Create(Student student)
        {
            student.Status = true;

            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = context.Students.FirstOrDefault(d => d.Id == id);
            if (student != null)
            {
                student.Status = false;
                context.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            var students = context.Students.Where(d => d.Status == true).AsNoTracking().ToList();
            return students;
        }

        public Student GetById(int id)
        {
            var student = context.Students.AsNoTracking().FirstOrDefault(d => d.Id == id);
            return student;
        }

        public void Update(Student student)
        {
            student.Status = true;
            context.Update(student);
            context.SaveChanges();
        }
    }
}
