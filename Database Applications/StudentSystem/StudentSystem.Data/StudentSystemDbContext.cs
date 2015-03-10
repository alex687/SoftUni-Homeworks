namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystem.Model;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystem")
        {
          //  var ensureDLLIsCopied =
         //System.Data.Entity.SqlServer.SqlProviderServices.Instance;   
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Resource> Resources { get; set; }

    }
}
