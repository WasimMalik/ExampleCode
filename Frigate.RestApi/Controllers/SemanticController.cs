using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frigate.Core.Interfaces.AppService;
using Frigate.Commons.Models.Semantic;
using Microsoft.AspNetCore.Mvc;


namespace Frigate.RestApi.Controllers
{
    [Route("api/[controller]")]
    public class SemanticController : ControllerBase
    {
        private readonly ISemanticService semanticService;

        public SemanticController(ISemanticService semanticService)
        {
            this.semanticService = semanticService;
        }

        [HttpGet]
        [Route("getSemantic/{semanticId}")]
        public IActionResult GetSemantic(int semanticId)
        {
            return Ok(this.semanticService.GetSemantic(semanticId));
        }

        [HttpGet]
        [Route("GetAllSemantic")]
        public IActionResult GetAllSemantic()
        {
            return Ok(this.semanticService.GetAllSemantic());
        }

        [HttpPost]
        [Route("createSemanticDetails")]
        public IActionResult CreateSemanticDetails([FromBody]CreateSemanticViewDetailsRequest request)
        {
            if (request != null && request.SemanticId != 0 && request.SemanticTableObj != null && request.SemanticTableObj.Count() > 0)
            {
                var isCreated = semanticService.CreateSemanticViewDetails(request);
                if (isCreated)
                {
                    return Ok(new CreateSemanticResponse()
                    {
                        Message = $"Semantic View details successfully updated.",
                        Success = true,
                        SemanticId = request.SemanticId
                    });
                }
                else
                {
                    return BadRequest(new CreateSemanticResponse()
                    {
                        Message = $"Semantic View details not updated.",
                        Success = false,
                        SemanticId = 0
                    });
                }
            }
            else
            {
                return BadRequest(new CreateSemanticResponse()
                {
                    Message = $"Data is invalid",
                    Success = false,
                    SemanticId = 0
                });
            }
        }



        [HttpPost]
        [Route("createSemantic")]
        public IActionResult CreateSemantic([FromBody]CreateSemanticRequest request)
        {
            if (request != null && !string.IsNullOrEmpty(request.Name))
            {
                var semanticId = semanticService.CreateSemanticView(request.Name);
                if (semanticId > 0)
                {
                    return Ok(new CreateSemanticResponse()
                    {
                        Message = $"Semantic View: {request.Name} successfully created.",
                        Success = true,
                        SemanticId = semanticId
                    });
                }
                else
                {
                    return BadRequest(new CreateSemanticResponse()
                    {
                        Message = $"Semantic View: {request.Name} not created or it already exists.",
                        Success = false,
                        SemanticId = 0
                    });
                }
            }
            else
            {
                return BadRequest(new CreateSemanticResponse()
                {
                    Message = $"Data is invalid",
                    Success = false,
                    SemanticId = 0
                });
            }
        }


        [HttpPost]
        [Route("renameSemantic")]
        public IActionResult RenameSemanticView([FromBody]RenameSemanticRequest request)
        {
            if (request != null && !string.IsNullOrEmpty(request.Name))
            {
                var semanticId = semanticService.RenameSemanticView(request.DashboardId, request.Name);
                if (semanticId > 0)
                {
                    return Ok(new CreateSemanticResponse()
                    {
                        Message = $"Semantic View successfully renamed.",
                        Success = true,
                        SemanticId = request.DashboardId
                    });
                }
                else
                {
                    return Ok(new CreateSemanticResponse()
                    {
                        Message = $"Semantic View is not updated or name already exists",
                        Success = false,
                        SemanticId = request.DashboardId
                    });
                }
            }
            else
            {
                return BadRequest(new CreateSemanticResponse()
                {
                    Message = $"Data is invalid",
                    Success = false,
                    SemanticId = request.DashboardId
                });
            }
        }


        [HttpPost]
        [Route("deleteSemantic")]
        public IActionResult DeleteSemanticView([FromBody]RenameSemanticRequest request)
        {
            if (request != null && !string.IsNullOrEmpty(request.Name))
            {
                var semanticId = semanticService.DeleteSemanticView(request.DashboardId, request.Name);
                if (semanticId > 0)
                {
                    return Ok(new CreateSemanticResponse()
                    {
                        Message = $"Semantic View successfully deleted.",
                        Success = true,
                        SemanticId = request.DashboardId
                    });
                }
                else
                {
                    return Ok(new CreateSemanticResponse()
                    {
                        Message = $"Semantic View is not deleted.",
                        Success = false,
                        SemanticId = request.DashboardId
                    });
                }
            }
            else
            {
                return BadRequest(new CreateSemanticResponse()
                {
                    Message = $"Data is invalid",
                    Success = false,
                    SemanticId = request.DashboardId
                });
            }
        }
    }
}
