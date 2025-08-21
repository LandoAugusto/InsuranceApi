using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public  interface IBorrowerAppealFeeRepository: IDomainRepository<BorrowerAppealFee>    
    {
        Task<IEnumerable<BorrowerAppealFee?>> ListAsync(int? productId, int? coverageId, int? takerId, int? termTypeId, RecordStatusEnum recordStatus);
    }
}
