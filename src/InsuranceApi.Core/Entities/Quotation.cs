using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Quotation : IIdentityEntity
    {
        public int QuotationId { get; set; }
    }
}
