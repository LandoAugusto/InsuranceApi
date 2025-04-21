using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationWarrantyComplement : IIdentityEntity
    {
        public int QuotationWarrantyComplementId { get; set; }
        public int QuotationWarrantyId { get; set; }
        public string? BiddingNumber { get; set; }
        public string? ContractNumber { get; set; }
        public decimal? ContractValue { get; set; }        
        public string? NoticeNumber { get; set; }
        public decimal? AppealDepositValue { get; set; }
        public int? TermTypedId { get; set; }
        public string? LawsuitNumber { get; set; }
        public int? CourtOfAppealId { get; set; }
        public decimal? MaxAppealDepositValue { get; set; }
        public int? CivilCourtId { get; set; }
        public int? InsuredType { get; set; }
        public decimal? DiscussionValue { get; set; }
        public int? LawsuitId { get; set; }
        public string? LawsuitComplement { get; set; }
        public Int64? CdaNumber { get; set; }
        public int? TributeId { get; set; }
        public string? ObjectDescription { get; set; }
        public string? TributeComplement { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual QuotationWarranty QuotationWarranty { get; set; } = null!;
    }
}

