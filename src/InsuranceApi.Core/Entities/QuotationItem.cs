using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationItem : IIdentityEntity
    {
        public int QuotationId { get; set; }
        public int NumberItem { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Quotation Quotation { get; set; } = null!;
        public virtual ICollection<QuotationRiskLocationItem> QuotationRiskLocationItem { get; set; } = new HashSet<QuotationRiskLocationItem>();
        public virtual ICollection<QuotationAutoItem> QuotationAutoItem { get; set; } = new HashSet<QuotationAutoItem>();
        public virtual ICollection<QuotationCoverage> QuotationCoverage { get; set; } = new HashSet<QuotationCoverage>();
        public virtual ICollection<QuotationQuestionnaireItem> QuotationQuestionnaireItem { get; set; } = new HashSet<QuotationQuestionnaireItem>();
    }
}
