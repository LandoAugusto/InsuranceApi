using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationCoverage : IIdentityEntity
    {
        public int QuotationCoverageId { get; set; }
        public int QuotationItemId { get; set; }
        public virtual QuotationItem QuotationItem { get; set; } = null!;
        public virtual ICollection<QuotationCoverageFranchise> QuotationCoverageFranchise { get; set; } = new HashSet<QuotationCoverageFranchise>();
    }
}
