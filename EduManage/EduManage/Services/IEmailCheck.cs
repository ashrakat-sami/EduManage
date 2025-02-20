namespace EduManage.Services
{
    public interface IEmailCheck
    {
        bool CheckEmailExistance(string Email, int Id);
    }
}
