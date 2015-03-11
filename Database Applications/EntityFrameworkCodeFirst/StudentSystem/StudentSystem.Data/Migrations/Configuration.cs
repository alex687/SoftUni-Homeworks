namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

             ICollection<Resource> resources = new List<Resource>();
            ICollection<Course> courses = new List<Course>();
            ICollection<Student> students = new List<Student>();
            ICollection<Homework> homeworks = new List<Homework>();

            // Seed materials
            Resource eFCFDemo = new Resource
            {
                Id = 1,
                Name = "EFCF StudentSystem Demo",
                Link = "https://github.com/SoftUni/Database-Applications/tree/master/1.%20Entity-Framework",
                Type = ResourceType.Other
            };

            resources.Add(eFCFDemo);

            Resource eFCFPres = new Resource
            {
                Id = 2,
                Name = "EFCF StudentSystem Presentation",
                Link = "https://softuni.bg/downloads/svn/db-apps/March-2015/0.%20Database-Applications-Course-Introduction.pptx",
                Type = ResourceType.Presentation
            };

            resources.Add(eFCFPres);

            Resource eFCFVideo = new Resource
            {
                Id = 3,
                Name = "EFCF StudentSystem Demo",
                Link = "https://softuni.bg/Trainings/Resources/Video/3526/Video-2-March-2015-Vladimir-Georgiev-Database-Applications-Mar-2015",
                Type = ResourceType.Video
            };

            resources.Add(eFCFVideo);

            Resource JSIntroDemo = new Resource
            {
                Id = 4,
                Name = "JS Introduction Demo",
                Link = "https://github.com/SoftUni/JS/tree/master/JSIntro",
                Type = ResourceType.Document
            };

            resources.Add(JSIntroDemo);

            Resource JSIntroPres = new Resource
            {
                Id = 5,
                Name = "JS Introduction Presentation",
                Link = "https://github.com/SoftUni/JS/tree/master/JSIntroPres",
                Type = ResourceType.Other
            };

            resources.Add(JSIntroPres);

            Resource JSIntroVideo = new Resource
            {
                Id = 6,
                Name = "JS Introduction Video",
                Link = "https://github.com/SoftUni/JS/tree/master/JSIntroVideo",
                Type = ResourceType.Other
            };

            resources.Add(JSIntroVideo);


            Course dBAppsCourse = new Course
            {
                Id = 1,
                Name = "Database Applications",
                StartDate = new DateTime(2015, 02, 28),
                EndDate = new DateTime(2015, 03, 29),
                Price = 0m
            };

            Course JSBasicsCourse = new Course
            {
                Id = 2,
                Name = "JavaScript Basics",
                Description = "Basic knowledge on JS",
                StartDate = new DateTime(2014, 02, 28),
                EndDate = new DateTime(2014, 03, 29),
                Price = 50.25m
            };

            Homework eFCFHw = new Homework
            {
                Id = 1,
                Content = "some content",
                ContentType = "text",
                SentOn = DateTime.Now,
                Course = dBAppsCourse,
                CourseId = dBAppsCourse.Id
            };

            Homework jSHw = new Homework
            {
                Id = 2,
                Content = "some js content",
                ContentType = "js",
                SentOn = new DateTime(2014, 06, 15),
                Course = JSBasicsCourse,
                CourseId = JSBasicsCourse.Id
            };

            Student gosho = new Student
            {
                FirstName = "Georgi",
                LastName = "Georgiev",
                RegistrationDate = new DateTime(2014, 05, 05),
                Birthday = new DateTime(1998, 12, 25),
                PhoneNumber = "6516165165"
            };

            Student pesho = new Student
            {
               FirstName = "Petar",
                LastName = "Petrov",
                RegistrationDate = new DateTime(2015, 01, 06),
               Birthday = new DateTime(1989, 12, 25),
                PhoneNumber = "23434534645675678"
            };

            Student emil = new Student
            {
                FirstName = "Emil",
                LastName = "Emilov",
                RegistrationDate = new DateTime(2014, 02, 05),
                Birthday = new DateTime(1978, 12, 25),
                PhoneNumber = "151651516516"
            };

            Student ivana = new Student
            {
                FirstName = "Ivana",
                LastName = "Emilova",
                RegistrationDate = new DateTime(2014, 05, 05),
                Birthday = new DateTime(1998, 12, 25),
                PhoneNumber = "638735463"
            };

            Student milka = new Student
            {
                FirstName = "Milka",
                LastName = "Emilova",
                RegistrationDate = new DateTime(2013, 05, 05),
                Birthday = new DateTime(1968, 12, 25),
                PhoneNumber = "123456798"
            };

            // Seed courses
            dBAppsCourse.Resources.Add(eFCFDemo);
            dBAppsCourse.Resources.Add(eFCFPres);
            dBAppsCourse.Resources.Add(eFCFVideo);
            dBAppsCourse.Students.Add(ivana);
            dBAppsCourse.Students.Add(pesho);
            dBAppsCourse.Students.Add(milka);
            dBAppsCourse.Homeworks.Add(eFCFHw);
            courses.Add(dBAppsCourse);

            JSBasicsCourse.Resources.Add(JSIntroDemo);
            JSBasicsCourse.Resources.Add(JSIntroPres);
            JSBasicsCourse.Resources.Add(JSIntroVideo);
            JSBasicsCourse.Students.Add(pesho);
            JSBasicsCourse.Students.Add(gosho);
            JSBasicsCourse.Students.Add(milka);
            JSBasicsCourse.Homeworks.Add(jSHw);
            courses.Add(JSBasicsCourse);

            //// Seed homeworks
            eFCFHw.Student = gosho;
            eFCFHw.StudentId = gosho.Id;
            jSHw.Student = pesho;
            jSHw.StudentId = pesho.Id;

            homeworks.Add(eFCFHw);
            homeworks.Add(jSHw);


            gosho.Courses.Add(JSBasicsCourse);
            students.Add(gosho);

            pesho.Courses.Add(JSBasicsCourse);
            pesho.Courses.Add(dBAppsCourse);
            students.Add(pesho);

            students.Add(emil);

            ivana.Courses.Add(dBAppsCourse);
            students.Add(ivana);

            milka.Courses.Add(dBAppsCourse);
            milka.Courses.Add(JSBasicsCourse);
            students.Add(milka);

            // Add objects to context's data
            foreach (Resource material in resources)
            {
                context.Resources.Add(material);
            }

            foreach (Course course in courses)
            {
                context.Courses.Add(course);
            }

            foreach (Student student in students)
            {
                context.Students.Add(student);
            }

            foreach (Homework homework in homeworks)
            {
                context.Homeworks.Add(homework);
            }


            base.Seed(context);
        }
    }
}
