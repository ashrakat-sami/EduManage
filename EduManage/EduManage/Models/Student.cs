namespace EduManage.Models
{
    public class Student:Person
    {

        
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public bool Status { get; set; }


        public virtual Department Department { get; set; }

        public virtual List<StdCourseRelation> StudentCourses { get; set; } = new List<StdCourseRelation>();


    }
}
