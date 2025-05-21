using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Service.Client.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class BrokerAppService(IMapper mapper, IBrokerRepository brokerRepository, IBrokerService brokerClientService) : IBrokerAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBrokerRepository _brokerRepository = brokerRepository;
        private readonly IBrokerService _brokerClientService = brokerClientService;
        public async Task<BrokerModel?> GetByIdAsync(int? brokerId, RecordStatusEnum recordStatus) =>
            _mapper.Map<BrokerModel>(await _brokerRepository.GetByIdAsync(brokerId, recordStatus));


        public async Task<BrokerModel?> GetByIdAsync(int brokerId)
        {
            var response = await _brokerClientService.GetByIdAsync(brokerId);
            if (response == null) return null;

            return new BrokerModel()
            {
                Id = response.id_pessoa,
                Name = response.nm_pessoa,
                Document = response.nr_cnpj_cpf.ToString(),
            };
        }

        public async Task<IEnumerable<BrokerModel>?> GetByNameAsync(string name)
        {
            var response = await _brokerClientService.GetByNameAsync(name);
            if (response == null) return null;

            var list = new List<BrokerModel>();
            foreach (var item in response)
            {
                var b = new BrokerModel()
                {
                    Id = item.id_pessoa,
                    Name = item.nm_pessoa,
                    Document = item.nr_cnpj_cpf.ToString(),
                };

                list.Add(b);
            }
            return list;
        }
    }
}
