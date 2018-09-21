using BL.ModelDTO;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class TestController : ApiController
    {
        private ITestService testService;
        public TestController(ITestService testService)
        {
            this.testService = testService;
        }


        [HttpGet]
        public List<TestDTO> Get()
        {
            return  testService.GetAllTests();
        }

        [HttpGet]
        public TestDTO Get(int id)
        {
            return testService.GetTestByID(id);
        }



        [HttpPost]
        public bool Post(TestDTO data)
        {
            return testService.UpdateTestResult(data);
        }
        [HttpPut]
        public bool Put(TestDTO data)
        {
            return testService.AddTestResult(data);
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            return testService.DeleteTest(id);
        }
    }
}