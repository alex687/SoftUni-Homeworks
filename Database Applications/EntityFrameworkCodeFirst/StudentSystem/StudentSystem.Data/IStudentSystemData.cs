namespace StudentSystem.Data
{
    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;

    public interface IStudentSystemData
    {
        IGenericRepository<Student> Students { get; }

        IGenericRepository<Course> Courses { get; }

        IGenericRepository<Homework> Homeworks { get; }

        IGenericRepository<Resource> Resources { get; }

        int SaveChanges();
    }
}

