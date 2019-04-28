using Frigate.Core.Interfaces.DbInterfaces;
using Frigate.Infrastructure.DbPluginApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Frigate.Infrastructure.DbImplementation.Models;
using Frigate.Commons.Models.Semantic;
using Z.EntityFramework.Plus;

namespace Frigate.Infrastructure.DbImplementation.Repositories
{
    public class SemanticRepository : ISemanticRepository
    {
        private readonly IDbPlugin dbPlugin;
        public SemanticRepository(IDbPlugin dbPlugin)
        {
            this.dbPlugin = dbPlugin;
        }
        public int CreateSemanticView(string name)
        {
            return this.dbPlugin.Execute(context =>
            {
                if (context.SemanticViews.Count(x => x.SemanticViewName == name && x.IsActive == true) > 0)
                {
                    return 0;
                }
                var semanticView = new SemanticView()
                {
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now,
                    SemanticViewName = name
                };
                context.SemanticViews.Add(semanticView);
                context.SaveChanges();
                return semanticView.dashboardId;
            });
        }

        public bool CreateSemanticViewDetails(CreateSemanticViewDetailsRequest request)
        {
            return this.dbPlugin.Execute(context =>
            {
                try
                {
                    context.SemanticViewDetails.Where(x => x.SemanticViewId == request.SemanticId).Delete();
                    foreach (var svd in request.SemanticTableObj)
                    {
                        context.SemanticViewDetails.Add(new SemanticViewDetails()
                        {
                            TableName = request.TableName,
                            SemanticColumnAlias = svd.Alias == null? svd.Name: svd.Alias   ,
                            SemanticColumnDescription = svd.Description,
                            SemanticColumnName = svd.Name,
                            SemanticColumnType = svd.Type,
                            SemanticViewId = request.SemanticId
                        });
                    }
                    context.SaveChanges();
                    return true;
                   
                }
                catch (Exception ex)
                {
                    return false;
                }
            });
        }

        public GetSemanticResponse GetSemantic(int semanticId)
        {
            return dbPlugin.Execute((context) =>
            {
                try
                {
                    var semantic = context.SemanticViews.FirstOrDefault(x => x.dashboardId == semanticId);
                    var tableObjs = context.SemanticViewDetails.Where(x => x.SemanticViewId == semanticId).Select(x => new SemanticTableObject()
                    {
                        Alias = x.SemanticColumnAlias,
                        Description = x.SemanticColumnDescription,
                        Name = x.SemanticColumnName,
                        Type = x.SemanticColumnType,
                        TableName = x.TableName,
                    }).ToList();

                    var response = new GetSemanticResponse()
                    {
                        name = semantic.SemanticViewName,
                        dashboardId = semantic.dashboardId,
                        Parent = 0,
                        IsFolder = false,
                        IsDeleted = false,
                        widgets = tableObjs,
                        Success = true
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    return new GetSemanticResponse();
                }
            });
        }

        public List<GetSemanticResponse> GetAllSemantic()
        {
            return dbPlugin.Execute((context) =>
            {
                try
                {
                    List<SemanticView> views = context.SemanticViews.Where(p => p.IsActive == true).ToList();
                    List<GetSemanticResponse> semanticviews = views.Select(p => new GetSemanticResponse() {
                        name = p.SemanticViewName,
                        dashboardId = p.dashboardId,
                        Parent = 0,
                        IsFolder = false,
                        IsDeleted = false,
                        widgets = new List<SemanticTableObject>(),
                        Success = true
                    }).OrderBy(x => x.name).ToList();
                    return semanticviews;
                }
                catch (Exception ex)
                {
                    return new List<GetSemanticResponse>();
                }
            });
        }

        public int RenameSemanticView(int semanticId, string name)
        {
            return this.dbPlugin.Execute(context =>
            {
                if (context.SemanticViews.Count(x => x.SemanticViewName == name && x.IsActive == true) > 0)
                {
                    return -1;
                }

                var _semantic = context.SemanticViews.FirstOrDefault(x => x.dashboardId == semanticId); 
                if (_semantic != null)
                {
                    if (context.SemanticViews.Where(x => x.dashboardId == semanticId && x.SemanticViewName.Equals(name) && x.IsActive == true).ToList().FirstOrDefault() == null)
                    {
                        _semantic.SemanticViewName = name;
                        _semantic.ModifiedOn = DateTime.Now;
                    }
                }
                context.SaveChanges();
                return 1;
            });
        }

        public int DeleteSemanticView(int semanticId, string name)
        {
            return this.dbPlugin.Execute(context =>
            {
                var _semantic = context.SemanticViews.FirstOrDefault(x => x.dashboardId == semanticId);
                if (_semantic != null)
                {
                    if (context.SemanticViews.Where(x => x.dashboardId == semanticId && x.SemanticViewName.Equals(name) && x.IsActive == true).ToList().FirstOrDefault() != null)
                    {
                        _semantic.IsActive = false;
                        _semantic.ModifiedOn = DateTime.Now;
                    }
                }
                context.SaveChanges();
                return 1;
            });
        }
    }
}
