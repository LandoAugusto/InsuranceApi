using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationQuestionnaireItem : IIdentityEntity
    {
        public int QuotationQuestionnaireItemId { get; set; }
        public int QuotationItemId { get; set; }
        public virtual QuotationItem QuotationItem { get; set; } = null!;
    }
}
