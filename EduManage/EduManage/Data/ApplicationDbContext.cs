namespace EduManage.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<StdCourseRelation> StudentCourses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EduManage;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StdCourseRelation>(s =>
            {
                s.HasKey(x => new {x.StdId, x.CrsId});
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
