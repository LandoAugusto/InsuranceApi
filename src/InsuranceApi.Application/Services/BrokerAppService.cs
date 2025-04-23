using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class BrokerAppService(IMapper mapper, IBrokerRepository brokerRepository) : IBrokerAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBrokerRepository _brokerRepository = brokerRepository;

        public async Task<BrokerModel?> GetByIdAsync(int? brokerId, RecordStatusEnum recordStatus) =>
            _mapper.Map<BrokerModel>(await _brokerRepository.GetByIdAsync(brokerId, recordStatus));



    }
}
