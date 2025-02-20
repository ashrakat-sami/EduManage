
using EduManage.Data;

namespace EduManage.Services
{
    public class DepartmentService : IDepartment
    {
        ApplicationDbContext context=new ApplicationDbContext();

        

        public void Create(Department department)
        {
            department.Status = true;

            context.Departments.Add(department);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dept=context.Departments.FirstOrDefault(d=>d.Id==id);
            if (dept != null)
            {
                dept.Status = false;
                context.SaveChanges();
            }
        }

        public List<Department> GetAll()
        {
           var depts= context.Departments.Where(d=>d.Status==true).AsNoTracking().ToList();
            return depts;
        }

        public Department GetById(int id)
        {
            var dept = context.Departments.AsNoTracking().FirstOrDefault(d => d.Id == id);
              return dept;
        }

        public void Update(Department department)
        {
            department.Status = true;
            context.Update(department);
            context.SaveChanges();
        }
    }
}
