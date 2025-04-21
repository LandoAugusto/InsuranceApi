using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationAutoItem : IIdentityEntity
    {
        public int QuotationAutoItemId { get; set; }
        public int QuotationItemId { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual QuotationItem QuotationItem { get; set; } = null!;
    }
}
