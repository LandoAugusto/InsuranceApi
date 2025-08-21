using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class AppealFeeAppService(IMapper mapper, IAppealFeeRepository appealFeeRepository) : IAppealFeeAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAppealFeeRepository _appealFeeRepository = appealFeeRepository;


        public async Task<FlexRateModel?> GetAsync(int appealFeeId)
        {
            var entidade = await _appealFeeRepository.GetByIdAsync(appealFeeId);

            if (entidade == null) return null;
            return _mapper.Map<FlexRateModel>(entidade);
        }

        public async Task<IEnumerable<AppealFeeModel?>> ListAsync(AppealFeeFilterModel request)
        {
            var recordStatus = (request.StatusId == null || request.StatusId == 2) ? RecordStatusEnum.Ativo : RecordStatusEnum.Inativo;

            var appealFee = await _appealFeeRepository.ListAsync(request.InsuredAmountValueMin, request.InsuredAmountValueMax, request.PremiumValue, request.TermTypeId, recordStatus);
            if (!appealFee.IsAny<AppealFee>()) return null;

            return _mapper.Map<IEnumerable<AppealFeeModel>>(appealFee);
        }
    }
}
