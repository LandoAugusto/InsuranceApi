using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class BorrowerAppService(IMapper mapper, IBorrowerRepository borrowerRepository) : IBorrowerAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBorrowerRepository _borrowerRepository = borrowerRepository;

        public async Task<IEnumerable<BorrowerModel>?> ListAsync(int? brokerId, string name, RecordStatusEnum recordStatus)
        {
            var result = await _borrowerRepository.ListAsync(brokerId, name, recordStatus);
            return _mapper.Map<IEnumerable<BorrowerModel>>(result);
        }   
    }
}
