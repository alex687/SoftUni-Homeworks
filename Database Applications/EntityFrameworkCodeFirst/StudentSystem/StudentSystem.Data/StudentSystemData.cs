namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;

    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;

    public class StudentSystemData : IStudentSystemData
    {
        private readonly IStudentSystemDbContext context;

        private readonly Dictionary<Type, object> repositories;

        public StudentSystemData()
            : this(new StudentSystemDbContext())
        {
        }

        public StudentSystemData(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Student> Students
        {
            get
            {
                return (IGenericRepository<Student>)this.GetRepository(typeof(GenericRepository<Student>));
            }
        }

        public IGenericRepository<Course> Courses
        {
            get
            {
                return (IGenericRepository<Course>)this.GetRepository(typeof(GenericRepository<Course>));
            }
        }

        public IGenericRepository<Homework> Homeworks
        {
            get
            {
                return (IGenericRepository<Homework>)this.GetRepository(typeof(GenericRepository<Homework>));
            }
        }

        public IGenericRepository<Resource> Resources
        {
            get
            {
                return (IGenericRepository<Resource>)this.GetRepository(typeof(GenericRepository<Resource>));
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private object GetRepository(Type repositoryType)
        {
            if (this.repositories.ContainsKey(repositoryType))
            {
                return this.repositories[repositoryType];
            }

            var newRepository = Activator.CreateInstance(repositoryType, this.context);
            this.repositories.Add(repositoryType, newRepository);

            return newRepository;
        }
    }
}
