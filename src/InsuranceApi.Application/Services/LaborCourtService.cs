using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class LaborCourtService(IMapper mapper, ILaborCourtRepository laborCourtRepository) : ILaborCourtService
    {
        private readonly IMapper _mapper = mapper;
        private readonly ILaborCourtRepository _laborCourtRepository = laborCourtRepository;

    

        public async Task<IEnumerable<LaborCourtModel>?> ListAsync(LaborCourtFilterModel filter)
        {
            var recordStatus = (filter.StatusId == null || filter.StatusId == 2) ? RecordStatusEnum.Ativo : RecordStatusEnum.Inativo;

            var entidade = await _laborCourtRepository.ListAsync(filter.Name, filter.StateId, recordStatus);
            if (!entidade.IsAny<LaborCourt>()) return null;

            return _mapper.Map<IEnumerable<LaborCourtModel>>(entidade);
        }
    }
}
