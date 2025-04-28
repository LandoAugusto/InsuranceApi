using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Service.Client.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class BorrowerAppService(IMapper mapper, IBorrowerRepository borrowerRepository, IBorrowerClientService borrowerClientService) : IBorrowerAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBorrowerRepository _borrowerRepository = borrowerRepository;
        private readonly IBorrowerClientService _borrowerClientService = borrowerClientService;
        public async Task<IEnumerable<BorrowerModel>?> ListAsync(int? brokerId, string name, RecordStatusEnum recordStatus)
        {
            var result = await _borrowerRepository.ListAsync(brokerId, name, recordStatus);
            return _mapper.Map<IEnumerable<BorrowerModel>>(result);
        }


        public async Task<IEnumerable<BorrowerModel>?> ListAsync(int brokerId, string? name)
        {
            var response = await _borrowerClientService.ListAsync(brokerId, name);
            if (response == null) return null;

            var list = new List<BorrowerModel>();
            foreach (var item in response)
            {
                var borrower = new BorrowerModel()
                {
                    Id = item.id_pessoa,
                    Name = item.nm_tomador,
                    Document = item.nr_cnpj.ToString(),
                    ExpirationDate = item.dt_validade,
                    AvailableLimit = item.vl_limite_disponivel.Value
                };

                list.Add(borrower);
            }

            return list;
        }
    }
}
