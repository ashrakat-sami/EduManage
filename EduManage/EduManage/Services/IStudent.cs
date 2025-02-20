namespace EduManage.Services
{
    public interface IStudent:IEmailCheck
    {
        List<Student> GetAll();

        Student GetById(int id);

        void Create(Student student);

        void Update(Student student);

        void Delete(int id);
    }
}
