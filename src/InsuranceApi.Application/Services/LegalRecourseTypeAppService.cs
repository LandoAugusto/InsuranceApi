using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;

namespace InsuranceApi.Application.Services
{
    internal class LegalRecourseTypeAppService(IMapper mapper, ILegalRecourseTypeService legalRecourseTypeService) : ILegalRecourseTypeAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly ILegalRecourseTypeService _legalRecourseTypeService = legalRecourseTypeService;
        
        public async Task<IEnumerable<LegalRecourseTypeModel>?> GetAllAsync()
        {
            var response = await _legalRecourseTypeService.GetAllAsync();
            if (!response.IsAny<LegalRecourseTypeModel>()) return null;
            
            return response;
        }
    }
}
