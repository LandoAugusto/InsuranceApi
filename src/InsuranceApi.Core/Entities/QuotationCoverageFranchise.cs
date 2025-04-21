using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationCoverageFranchise : IIdentityEntity
    {

        public int QuotationCoverageFranchiseId { get; set; }
        public int QuotationCoverageId { get; set; }
        public virtual QuotationCoverage QuotationCoverage { get; set; } = null!;
    }
}
