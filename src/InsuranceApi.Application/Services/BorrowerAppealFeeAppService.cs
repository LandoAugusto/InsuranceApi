using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;

namespace InsuranceApi.Application.Services
{
    public class BorrowerAppealFeeAppService(IMapper mapper, IBorrowerAppealFeeRepository borrowerAppealFeeRepository) 
        : IBorrowerAppealFeeAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBorrowerAppealFeeRepository _borrowerAppealFeeRepository = borrowerAppealFeeRepository;

        public async Task<BorrowerAppealFeeModel?> GetAsync(int appealFeeId)
        {
            var entidade = await _borrowerAppealFeeRepository.GetByIdAsync(appealFeeId);

            if (entidade == null) return null;
            return _mapper.Map<BorrowerAppealFeeModel>(entidade);
        }

        public async Task<IEnumerable<BorrowerAppealFeeModel>?> ListAsync(BorrowerAppealFeeFilterModel request)
        {
            var recordStatus = (request.StatusId == null || request.StatusId == 2) ? RecordStatusEnum.Ativo : RecordStatusEnum.Inativo;

            var appealFeeTaker = await _borrowerAppealFeeRepository.ListAsync(request.ProductId, request.CoverageId, request.TakerId, request.TermTypeId, recordStatus);
            if (!appealFeeTaker.IsAny<BorrowerAppealFee>()) return null;

            return _mapper.Map<IEnumerable<BorrowerAppealFeeModel>>(appealFeeTaker);
        }
    }
}
