namespace EduManage.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(15,100)]
        [Required]
        public int Capacity { get; set; }

        public virtual List<Student> Students { get; set; } = new List<Student>();

        public virtual List<Course> Courses { get; set; } = new List<Course>();


    }
}
