﻿using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Quotation : IIdentityEntity
    {
        public int QuotationId { get; set; }
        public int QuotationNumber { get; set; }
        public int VersionNumber { get; set; }
        public int EndorsementId { get; set; }
        public DateTime QuotationDate { get; set; }
        public int ProductVersionId { get; set; }
        public int BrokerId { get; set; }
        public int InsuranceTypeId { get; set; }
        public int Status { get; set; }
        public int CalculationTypeId { get; set; }
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
        public int RenovationInsurerId { get; set; }
        public string? RenovationPolicyNumber { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ICollection<QuotationWarranty> QuotationWarranty { get; set; } = new HashSet<QuotationWarranty>();
        public virtual ICollection<QuotationItem> QuotationItem { get; set; } = new HashSet<QuotationItem>();
        public virtual ICollection<QuotationCoBroker> QuotationCoBroker { get; set; } = new HashSet<QuotationCoBroker>();
        public virtual ICollection<Proposal> Proposal { get; set; } = new HashSet<Proposal>();

    }
}
