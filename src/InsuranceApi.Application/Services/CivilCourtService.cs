using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class CivilCourtService(IMapper mapper, ICivilCourtRepository civilCourtRepository) : ICivilCourtService
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICivilCourtRepository _civilCourtRepository = civilCourtRepository;
       
        public async Task<IEnumerable<CivilCourtModel>?> ListAsync(CivilCourtFilterModel filter)
        {
            var recordStatus = (filter.StatusId == null || filter.StatusId == 2) ? RecordStatusEnum.Ativo : RecordStatusEnum.Inativo;

            var entidade = await _civilCourtRepository.ListAsync(filter.Name, filter.LaborCourtId, filter.StateId, recordStatus);
            if (!entidade.IsAny<CivilCourt>()) return null;

            return _mapper.Map<IEnumerable<CivilCourtModel>>(entidade);
        }
    }
}
