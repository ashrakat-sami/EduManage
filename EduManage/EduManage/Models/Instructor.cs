namespace EduManage.Models
{
    public class Instructor:Person
    {
       
        public virtual List<Course> Courses { get; set; } = new List<Course>();
    }
}
