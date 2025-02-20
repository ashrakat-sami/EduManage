

namespace EduManage.Models
{
    public class StdCourseRelation
    {
        public int Degree { get; set; }

        [ForeignKey("Student")]
        public int? StdId { get; set; }
        [ForeignKey("Course")]
        public int? CrsId { get; set; }
        public bool Status { get; set; }


        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }


    }
}
