using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ModelDTO;
using Model;

namespace BL.Services
{
    public interface ITestService
    {
        List<TestDTO> GetAllTests();
        TestDTO GetTestByID(int id);
        bool UpdateTestResult(TestDTO data);
        bool AddTestResult(TestDTO data);
        bool DeleteTest(int id);
    }

    public class TestService : ITestService
    {
        ISubjectService subjectService;
        IStudentService studentService;
        public TestService(ISubjectService subjectService, IStudentService studentService)
        {
            this.studentService = studentService;
            this.subjectService = subjectService;
        }

        public bool AddTestResult(TestDTO data)
        {
            using (var ctx = new DBModel())
            {
               var studentId= studentService.AddStudent(data.student);
                var test = new Model.Models.Test()
                {
                    StudentId = studentId,
                    SubjectId = subjectService.GetSubjectIdByName(data.SubjectName),
                    Grade = data.Grade
                };
                var res = ctx.tests.Add(test);
                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteTest(int id)
        {
            using (var ctx = new DBModel())
            {

                var res = ctx.tests.Where(x => x.StudentId == id).ToList();
                ctx.tests.RemoveRange(res);
                return ctx.SaveChanges() > 0;
            }
        }

        public List<TestDTO> GetAllTests()
        {
            var tests = new List<TestDTO>();
            using (var ctx = new DBModel())
            {
                tests = ctx.tests.Include("Student").Include("Subject").Select(x => new TestDTO()
                {
                    Id = x.Id,
                    Grade = x.Grade,
                    StudentName = x.student.Name,
                    SubjectName = x.subject.Name,
                    StudentId =x.student.Id

                }).ToList();
            }
            return tests;
        }

        public TestDTO GetTestByID(int id)
        {
            var test = new TestDTO();
            using (var ctx = new DBModel())
            {
               test = ctx.tests.Where(x => x.Id == id).Select(x => new TestDTO()
                {
                    Id = x.Id,
                    Grade = x.Grade,
                    StudentId = x.StudentId,
                    SubjectName=x.subject.Name,
                    student= new StudentDTO(){
                     Id=   x.student.Id,
                     Email=x.student.Email,
                     JoinDate=x.student.JoinDate,
                     Name=x.student.Name
                    
                     
                    }                    
                }).FirstOrDefault();
            }
            return test;
        }

        public bool UpdateTestResult(TestDTO data)
        {
            using (var ctx = new DBModel())
            {
                var res = ctx.tests.FirstOrDefault(x => x.Id == data.Id);

                if (res != null)
                {
                    res.StudentId = data.StudentId;
                    res.SubjectId = subjectService.GetSubjectIdByName(data.SubjectName);
                    res.Grade = data.Grade;
                }
                studentService.UpdateStudent(data.student);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
