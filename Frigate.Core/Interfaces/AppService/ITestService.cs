using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Core.Interfaces.AppService
{
    public interface ITestService
    {
        IList<string> GetAllTestData();
    }
}
