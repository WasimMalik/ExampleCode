using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frigate.Core.Interfaces.AppService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frigate.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        [HttpGet]
        [Route("all")]
        public IList<string> GetAll()
        {
            return testService.GetAllTestData();
        }
    }
}