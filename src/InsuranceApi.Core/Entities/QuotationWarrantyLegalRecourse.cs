using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public  class QuotationWarrantyLegalRecourse : IIdentityEntity
    {
        public int QuotationWarrantyLegalRecourseId { get; set; }
        public int QuotationWarrantyId { get; set; }
        public virtual QuotationWarranty QuotationWarranty { get; set; } = null!;
    }
}
