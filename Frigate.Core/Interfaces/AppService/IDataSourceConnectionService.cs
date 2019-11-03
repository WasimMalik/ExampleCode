using Frigate.Commons.Models.DataSource;
using Frigate.Commons.Models.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Core.Interfaces.AppService
{
    public interface IDataSourceConnectionService
    {
        bool VerifyDataSource(DataSourceDetailsModel dataSource);

        List<GetDataSourceResponse> GetAllDataSource();
        GetDataSourceResponse GetDataSourceById(int Id);
        bool SaveDataSource(DataSourceDetailsModel dataSource);
    }
}
