using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BL.ModelDTO;
using BL.Services;

namespace WebApplication1.Controllers
{
    public class SubjectsController : ApiController
    {
        ISubjectService subjectService;
        public SubjectsController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet]
        public List<string> Get()
        {
            return subjectService.GetAllSubject();
        }


    }
}