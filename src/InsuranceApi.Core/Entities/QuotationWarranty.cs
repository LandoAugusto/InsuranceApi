using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationWarranty : IIdentityEntity
    {
        public int QuotationWarrantyId { get; set; }        
        public int VersionNumber { get; set; }
        public int EndorsementId { get; set; }
        public DateTime QuotationDate { get; set; }
        public int ProductVersionId { get; set; }
        public int BrokerId { get; set; }
        public int BorrowerId { get; set; }
        public int TotalNumberDays { get; set; }
        public DateTime StartCoverage { get; set; }
        public DateTime EndCoverage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal ValueTotalIs { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal NetPremium { get; set; }
        public decimal NetPremiumTariff { get; set; }
        public decimal NetPremiumAnnual { get; set; }
        public decimal ValueIof { get; set; }
        public decimal PercentageDiscount { get; set; }
        public decimal PercentageCommission { get; set; }
        public decimal PercentageGrievance { get; set; }
        public decimal RiskRate { get; set; }
        public bool IsFlexRateId { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ICollection<QuotationWarrantyClaimant> QuotationWarrantyClaimant { get; set; } = new HashSet<QuotationWarrantyClaimant>();
        public virtual ICollection<QuotationWarrantyComplement> QuotationWarrantyComplement { get; set; } = new HashSet<QuotationWarrantyComplement>();
        public virtual ICollection<QuotationWarrantyLegalRecourse> QuotationWarrantyLegalRecourse { get; set; } = new HashSet<QuotationWarrantyLegalRecourse>();
        
    }
}
