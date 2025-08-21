using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface IAppealFeeRepository: IDomainRepository<AppealFee>
    {
        Task<IEnumerable<AppealFee>?> ListAsync(decimal? insuredAmountValueMin, decimal? insuredAmountValueMax, decimal? premiumValue, int? termTypeId, RecordStatusEnum recordStatus);
    }
}
