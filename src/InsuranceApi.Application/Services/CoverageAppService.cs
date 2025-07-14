using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Infrastructure.Exceptions;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;
using System.Data;

namespace InsuranceApi.Application.Services
{
    internal class CoverageAppService(IProductVersionService productVersionService) : ICoverageAppService
    {
        private readonly IProductVersionService _productVersionService = productVersionService;

        public async Task<CoverageActivityLimitModel> GetCoverageLimitActivityAsync(CoverageActivityLimitFilterModel request)
        {
            var coverageLimit = await _productVersionService.GetCoverageActivityLimitAsync(request.ProductVersionId, request.CoverageId, request.ActivityId, request.ProfileId);
            if (coverageLimit == null)
            {
                throw new BusinessException("");
            }

            return null;
        }
    }
}
