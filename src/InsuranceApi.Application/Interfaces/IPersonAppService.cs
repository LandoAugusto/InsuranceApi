using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IPersonAppService
    {
        Task<PersonModel?> GetByDocumentAsync(int documentTypeId, string document);
    }
}
