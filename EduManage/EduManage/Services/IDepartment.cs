namespace EduManage.Services
{
    public interface IDepartment
    {
        List<Department> GetAll();

        Department GetById(int id);

        void Create(Department department);

        void Update(Department department);

        void Delete(int id);


    }
}
