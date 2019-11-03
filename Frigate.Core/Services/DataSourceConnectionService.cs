using Frigate.Commons.Models.DataSource;
using Frigate.Commons.Models.Semantic;
using Frigate.Core.Interfaces.AppService;
using Frigate.Core.Interfaces.DbInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Core.Services
{
    public class DataSourceConnectionService : IDataSourceConnectionService
    {
        private readonly IDataSourceRepository _datasourceRepository;
        public DataSourceConnectionService(IDataSourceRepository datasourceRepository)
        {
            this._datasourceRepository = datasourceRepository;
        }  
        public List<GetDataSourceResponse> GetAllDataSource()
        {
            return _datasourceRepository.GetAllDataSource();
        }
        public GetDataSourceResponse GetDataSourceById(int Id)
        {
            return _datasourceRepository.GetDataSourceById(Id);
        }
       
        public bool SaveDataSource(DataSourceDetailsModel dataSource)
        {
            return _datasourceRepository.SaveDataSource(dataSource);
        }

        public bool VerifyDataSource(DataSourceDetailsModel dataSource)
        {
            return _datasourceRepository.VerifyDataSource(dataSource);
        }
    }
}
