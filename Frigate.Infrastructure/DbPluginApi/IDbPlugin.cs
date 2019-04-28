using Frigate.Infrastructure.DbImplementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Frigate.Infrastructure.DbPluginApi
{
    public interface IDbPlugin
    {
        T Execute<T>(Func<FrigateDbContext, T> executor);
    }
}
