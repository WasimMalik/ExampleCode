using Frigate.Core.Interfaces.DbInterfaces;
using Frigate.Infrastructure.DbPluginApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Frigate.Infrastructure.DbImplementation.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly IDbPlugin dbPlugin;
        public TestRepository(IDbPlugin dbPlugin)
        {
            this.dbPlugin = dbPlugin;
        }

        public IList<string> GetAllTestData()
        {
            return dbPlugin.Execute(context =>
            {
                return context.TestTables.Select(x => x.TestTableData).ToList();
            });
        }
    }
}
