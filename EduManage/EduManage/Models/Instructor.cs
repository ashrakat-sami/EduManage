namespace EduManage.Models
{
    public class Instructor:Person
    {
        public bool Status { get; set; }


        public virtual List<Course> Courses { get; set; } = new List<Course>();
    }
}
