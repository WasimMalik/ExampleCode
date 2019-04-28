using Frigate.Core.Interfaces.AppService;
using Frigate.Core.Interfaces.DbInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Core.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository testRepository;
        public TestService(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        public IList<string> GetAllTestData()
        {
            return testRepository.GetAllTestData();
        }
    }
}
