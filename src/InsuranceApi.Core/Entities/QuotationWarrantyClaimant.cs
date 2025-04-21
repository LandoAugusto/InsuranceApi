using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationWarrantyClaimant : IIdentityEntity
    {
        public int QuotationWarrantyClaimantId { get; set; }
        public int QuotationWarrantyId { get; set; }
        public virtual QuotationWarranty QuotationWarranty { get; set; } = null!;
    }
}
