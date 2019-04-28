using System;
using System.Collections.Generic;
using System.Text;
using Frigate.Commons;
using Frigate.Commons.Models.Semantic;

namespace Frigate.Core.Interfaces.AppService
{
    public interface ISemanticService
    {
        int CreateSemanticView(string semanticViewName);
        bool CreateSemanticViewDetails(CreateSemanticViewDetailsRequest request);
        GetSemanticResponse GetSemantic(int semanticId);
        List<GetSemanticResponse>  GetAllSemantic();
        int RenameSemanticView(int semanticId, string semanticViewName);
        int DeleteSemanticView(int semanticId, string semanticViewName);
    }
}
