using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class LegalRecourseTypeService(IMapper mapper, ILegalRecourseTypeRepository legalRecourseTypeRepository, ILegalRecourseTypeParameterRepository legalRecourseTypeParameterRepository) : ILegalRecourseTypeService
    {
        private readonly IMapper _mapper = mapper;
        private readonly ILegalRecourseTypeRepository _legalRecourseTypeRepository = legalRecourseTypeRepository;
        private readonly ILegalRecourseTypeParameterRepository _legalRecourseTypeParameterRepository = legalRecourseTypeParameterRepository;

        public async Task<IEnumerable<LegalRecourseTypeModel>?> GetAllAsync(RecordStatusEnum recordStatus)
        {
            var entidade = await _legalRecourseTypeRepository.GetAllAsync(recordStatus);
            if (!entidade.IsAny<LegalRecourseType>()) return null;

            var response = _mapper.Map<IEnumerable<LegalRecourseTypeModel>>(entidade);
            foreach (var item in response)
            {
                var parameter = await _legalRecourseTypeParameterRepository.GetByLegalRecourseTypeIdAsync(item.LegalRecourseTypeId);
                if (parameter != null)
                {
                    item.ApeelDepositAmount = parameter.ApeelDepositAmount;
                }
            }

            return response;
        }
    }
}
