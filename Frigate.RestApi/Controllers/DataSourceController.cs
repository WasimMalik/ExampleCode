using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frigate.Commons.Models.DataSource;
using Frigate.Commons.Models.Semantic;
using Frigate.Core.Interfaces.AppService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frigate.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSourceController : ControllerBase
    {
        private readonly IDataSourceConnectionService _datasourceconnectionService;

        public DataSourceController(IDataSourceConnectionService datasourceconnectionService)
        {
            this._datasourceconnectionService = datasourceconnectionService;
        }

        [HttpPost]
        [Route("CreateDataSource")]
        public IActionResult VerifyDataSource(DataSourceDetailsModel dataSource)
        {
            var isValid =_datasourceconnectionService.VerifyDataSource(dataSource);
            if (isValid)
            {
                return Ok(new CreateDataSourceResponse()
                {
                    Message = $"Connectin establish successfully.",
                    Success = true
                   
                });
            }
            else
            {
                return BadRequest(new CreateDataSourceResponse()
                {
                    Message = $"Connectin string data not get successfully",
                    Success = false,
                    ConnectionString = ""
                });
            }
        }

        [HttpGet]
        [Route("GetAllConnectionDetails")]
        public List<GetDataSourceResponse> GetAllConnection()
        {
            return _datasourceconnectionService.GetAllDataSource();
        }
        [HttpPost]
        [Route("SaveDataSource")]
        public IActionResult SaveDataSource(DataSourceDetailsModel dataSource)
        {
            var isValid = _datasourceconnectionService.SaveDataSource(dataSource);
            if (isValid)
            {
                return Ok(new CreateDataSourceResponse()
                {
                    Message = $"Save Data successfully.",
                    Success = true

                });
            }
            else
            {
                return BadRequest(new CreateDataSourceResponse()
                {
                    Message = $"Error",
                    Success = false,
                    ConnectionString = ""
                });
            }
            //return _datasourceconnectionService.SaveDataSource(dataSource);
        }
        [HttpGet]
        [Route("GetDataSourceById")]
        public IActionResult GetDataSourceById(int Id)
        {
            return Ok(this._datasourceconnectionService.GetDataSourceById(Id));
        }
        }
}