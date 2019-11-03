
using Frigate.Core.Interfaces.DbInterfaces;
using Frigate.Infrastructure.DbPluginApi;
using Frigate.Infrastructure.DbImplementation.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Frigate.Infrastructure.DbImplementation.Models;
using Frigate.Commons.Models.Semantic;
using Frigate.Commons.Models.DataSource;
using Z.EntityFramework.Plus;

namespace Frigate.Infrastructure.DbImplementation.Repositories
{
    public class DataSourceConnectionRepository : IDataSourceRepository
    {
        private readonly IDbPlugin dbPlugin;
        public DataSourceConnectionRepository(IDbPlugin dbPlugin)
        {
            this.dbPlugin = dbPlugin;
        }       

        public bool VerifyDataSource(DataSourceDetailsModel dataSource)
        {
          
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", dataSource.ServerName, dataSource.Database, dataSource.User, dataSource.Password);
            try
            {
                Helper helper = new Helper(connectionString,dataSource.ConnectionType);
                if (helper.IsSqlConnection)
                {
                    return true;
                }
                else if(helper.IsMySqlConnection)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                   
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
       
        public List<GetDataSourceResponse> GetAllDataSource()
        {
            return dbPlugin.Execute((context) =>
            {
                try
                {
                    //List<DataSourceDetails> dataSourceDetails = context.datasourcedetail.Where(p => p.IsActive == true).ToList();
                    List<DataSourceDetails> dataSourceDetails = context.datasourcedetail.ToList();
                    List<GetDataSourceResponse> datasourceresponse = dataSourceDetails.Select(p => new GetDataSourceResponse()
                    {
                        ConnectionString = p.ConnectionString,
                        ConnectionType=p.ConnectionName,
                        Success = true
                    }).ToList();
                    return datasourceresponse;
                }
                catch (Exception ex)
                {
                    return new List<GetDataSourceResponse>();
                }
            });
        }

       

        public GetDataSourceResponse GetDataSourceById(int Id)
        {
            return dbPlugin.Execute((context) =>
            {
                try
                {
                    var source = context.datasourcedetail.FirstOrDefault(x => x.Id == Id);
                   

                    var response = new GetDataSourceResponse()
                    {
                        ConnectionString = source.ConnectionString,
                        ConnectionType = source.ConnectionName,                       
                        IsDeleted = false,                       
                        Success = true
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    return new GetDataSourceResponse();
                }
            });
        }
        public bool SaveDataSource(DataSourceDetailsModel request)
        {
            return this.dbPlugin.Execute(context =>
            {
                try
                {
                    //context.datasourcedetail.Where(x => x.Id == request.Id).Delete();
                    //foreach (var svd in request.DataSourceTableObj)
                    //{
                        context.datasourcedetail.Add(new DataSourceDetails()
                        {
                            ConnectionName = request.ConnectionType,                            
                            ConnectionString = "server="+request.ServerName + ";port=" + "3306" + ";Database=" + request.Database  + ";User=" + request.User + ";Password=" + request.Password,
                            IsActive=true,
                            CreatedBy=""
                        });
                    //}
                    context.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            });
        }

        public int DeleteDataSourceDetails(int Id)
        {
            return this.dbPlugin.Execute(context =>
            {
                var _semantic = context.datasourcedetail.FirstOrDefault(x => x.Id == Id);
                if (_semantic != null)
                {
                    if (context.datasourcedetail.Where(x => x.Id == Id).ToList().FirstOrDefault() != null)
                    {
                        _semantic.IsActive = false;
                        _semantic.ModifyBy = "";
                    }
                }
                context.SaveChanges();
                return 1;
            });
        }



    }
}
