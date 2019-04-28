using Frigate.Commons.Models.Semantic;
using Frigate.Core.Interfaces.AppService;
using Frigate.Core.Interfaces.DbInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Core.Services
{
    public class SemanticService : ISemanticService
    {
        private readonly ISemanticRepository semanticRepository;

        public SemanticService(ISemanticRepository semanticRepository)
        {
            this.semanticRepository = semanticRepository;
        }
        public int CreateSemanticView(string semanticViewName)
        {
            return this.semanticRepository.CreateSemanticView(semanticViewName);
        }

        public bool CreateSemanticViewDetails(CreateSemanticViewDetailsRequest request)
        {
            return this.semanticRepository.CreateSemanticViewDetails(request);
        }

        public GetSemanticResponse GetSemantic(int semanticId)
        {
            return this.semanticRepository.GetSemantic(semanticId);
        }

        public List<GetSemanticResponse> GetAllSemantic()
        {
            return this.semanticRepository.GetAllSemantic();
        }

        public int RenameSemanticView(int semanticId, string semanticViewName)
        {
            return this.semanticRepository.RenameSemanticView(semanticId, semanticViewName);
        }

        public int DeleteSemanticView(int semanticId, string semanticViewName)
        {
            return this.semanticRepository.DeleteSemanticView(semanticId, semanticViewName);
        }
    }
}
