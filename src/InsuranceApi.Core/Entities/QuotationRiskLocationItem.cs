using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationRiskLocationItem : IIdentityEntity
    {
        public int QuotationRiskLocationItemId { get; set; }
        public int QuotationItemId { get; set; }
        public virtual QuotationItem QuotationItem { get; set; } = null!;
    }
}
