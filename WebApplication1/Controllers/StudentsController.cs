using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BL.ModelDTO;
using BL.Services;

namespace WebApplication1.Controllers
{
    public class StudentsController : ApiController
    {
        IStudentService studentService;
        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public List<string> Get()
        {
            return studentService.GetAllStudents();
        }
        [HttpGet]
        public StudentDTO Get(int id)
        {
            return studentService.GetStudentById(id);
        }
        

    }
}