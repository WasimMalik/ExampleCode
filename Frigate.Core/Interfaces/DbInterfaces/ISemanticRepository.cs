using System;
using System.Collections.Generic;
using System.Text;
using Frigate.Commons.Models.Semantic;

namespace Frigate.Core.Interfaces.DbInterfaces
{
    public interface ISemanticRepository
    {
        int CreateSemanticView(string name);
        bool CreateSemanticViewDetails(CreateSemanticViewDetailsRequest request);
        GetSemanticResponse GetSemantic(int semanticId);
        List<GetSemanticResponse> GetAllSemantic();
        int RenameSemanticView(int semanticId, string name);
        int DeleteSemanticView(int semanticId, string name);
    }
}
