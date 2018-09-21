using Model.Models;
using System.Data.Entity;

namespace Model
{
    public class DBInitializer : CreateDatabaseIfNotExists<DBModel>
    {

        protected override void Seed(DBModel context)
        {
            Student s = new Student()
            {
                Id = 1,
                Name = "miri",
                Email = "pini@pini.com",
                JoinDate = System.DateTime.Now
            };
            Student s1 = new Student()
            {
                Id = 2,
                Name = "pini",
                Email = "miri@miri.com",
                JoinDate = System.DateTime.Now
            };
            Subject subject = new Subject()
            {
                Id = 1,
                Name = "math"
            };
            Subject subject1 = new Subject()
            {
                Id = 2,
                Name = "english"
            };
            Test test = new Test()
            {
                Id = 1,
                StudentId=2,
                SubjectId=2,
                Grade = 95.5
            };
            Test test1 = new Test()
            {
                Id = 2,
                StudentId = 1,
                SubjectId = 1,
                Grade = 97.5
            };

            context.students.Add(s);
            context.students.Add(s1);
            context.subjects.Add(subject);
            context.subjects.Add(subject1);
            context.tests.Add(test);
            context.tests.Add(test1);

        }
    }
}