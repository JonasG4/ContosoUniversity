using ContosoUniversity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{FirstMidName="Carson", LastName="Alexander", EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Jonas", LastName="Garcia", EnrollmentDate=DateTime.Parse("2015-09-10")},
                new Student{FirstMidName="Jefferson", LastName="Lopez", EnrollmentDate=DateTime.Parse("2020-05-08")}
            };
            foreach(Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050, Title="Chemistry", Credits=9},
            new Course{CourseID=1051, Title="Calculus", Credits=9},
            new Course{CourseID=1052, Title="Literature", Credits=4},
            };

            foreach(Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
             new Enrollment{StudentID=1, CourseID=1050, Grade=Grade.A},
             new Enrollment{StudentID=2, CourseID=1050, Grade=Grade.B},
             new Enrollment{StudentID=3, CourseID=1050, Grade=Grade.D}
            };

            foreach(Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }

            context.SaveChanges();
        }
    }
}
