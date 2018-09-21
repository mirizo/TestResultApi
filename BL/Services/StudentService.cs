using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ModelDTO;
using Model;

namespace BL.Services
{
    public interface IStudentService
    {
        List<string> GetAllStudents();
        int GetStudentIdByName(string studentName);
        int UpdateStudent(StudentDTO data);
        int AddStudent(StudentDTO data);
        StudentDTO GetStudentById(int id);
    }
    public class StudentService : IStudentService
    {

        public List<string> GetAllStudents()
        {
            var students = new List<string>();
            using (var ctx = new DBModel())
            {
                students = ctx.students.Select(x => x.Name).ToList();
            }
            return students;
        }

        public int GetStudentIdByName(string studentName)
        {
            using (var ctx = new DBModel())
            {
                return ctx.students.Where(x => x.Name == studentName).Select(x => x.Id).FirstOrDefault();
            }
        }


        public int UpdateStudent(StudentDTO std)
        {
            using (var ctx = new DBModel())
            {
                var res = ctx.students.FirstOrDefault(x => x.Id == std.Id);

                if (res != null)
                {
                    res.Name = std.Name;
                }
                ctx.SaveChanges();
                return std.Id;
            }
        }

        public int AddStudent(StudentDTO data)
        {
            using (var ctx = new DBModel())
            {
               var existStudent = ctx.students.Where(x => x.Email == data.Email).Select(x=> new StudentDTO()
               {
                   Id=x.Id,
                   Name=x.Name
               }).FirstOrDefault();
                if (existStudent!=null)
                {
                    return UpdateStudent(existStudent);

                }
                else
                {

                    var student = new Model.Models.Student()
                    {
                        Email = data.Email,
                        Name = data.Name,
                        JoinDate = DateTime.Now
                    };

                    ctx.students.Add(student);

                    ctx.SaveChanges();
                    return student.Id;
                }

            }
        }



        public StudentDTO GetStudentById(int id)
        {
            using (var ctx = new DBModel())
            {
                var stu = ctx.students.Where(x => x.Id == id).Select(x => new StudentDTO()
                {
                    Id = x.Id,
                    Email = x.Email,
                    JoinDate = x.JoinDate,
                    Name = x.Name
                }).FirstOrDefault();


                return stu;

            }
        }
    }
}
