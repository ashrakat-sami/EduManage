
namespace EduManage.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }
        public bool Status { get; set; }


        [ForeignKey("Department")]
        public int? DeptId { get; set; }

        public virtual Department Department { get; set; } = new Department();

        [ForeignKey("Instructor")]
        public int? InsId { get; set; }
        public virtual Instructor Instructor { get; set; }=new Instructor();
        public virtual   List<StdCourseRelation> CourseStudents { get; set; }=new List<StdCourseRelation>();
    }
}
