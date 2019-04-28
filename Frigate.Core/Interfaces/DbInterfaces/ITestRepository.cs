using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Core.Interfaces.DbInterfaces
{
    public interface ITestRepository
    {
        IList<string> GetAllTestData();
    }
}
