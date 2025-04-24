using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface IDocumentTypeRepository : IDomainRepository<DocumentType>
    {
        Task<IEnumerable<DocumentType>?> ListAsync(RecordStatusEnum recordStatus);
    }
}
