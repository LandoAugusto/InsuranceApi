using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class PersonAppService(IMapper mapper, IPersonRepository personRepository) : IPersonAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPersonRepository _personRepository = personRepository;
        public async Task<PersonModel?> GetByDocumentAsync(int documentTypeId, string document)
        {
            var entity = await _personRepository.GetByDocumentAsync(documentTypeId, document.Trim());
            if (entity == null) return null;
            var response = _mapper.Map<PersonModel>(entity);

            return response;
        }
    }
}
