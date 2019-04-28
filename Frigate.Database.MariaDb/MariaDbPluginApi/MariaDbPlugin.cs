using Frigate.Infrastructure.DbImplementation;
using Frigate.Infrastructure.DbPluginApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Database.MariaDb.MariaDbPluginApi
{
    public class MariaDbPlugin : IDbPlugin
    {
        private readonly IConfiguration configuration;
        
        public MariaDbPlugin(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public T Execute<T>(Func<FrigateDbContext, T> executor)
        {
            using(var context = new FrigateDbContext(configuration.GetConnectionString("FrigateConnectionString")))
            {
                return executor(context);
            }
        }
    }
}
