using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationCoBroker : IIdentityEntity
    {
        public int QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; } = null!;
    }
}
