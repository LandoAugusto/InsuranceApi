using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class BorrowerAppealFee : IIdentityEntity
    {
        public int TakerAppealFeeId { get; set; }
        public int TakerId { get; set; }
        public int ProductId { get; set; }
        public int CoverageId { get; set; }
        public decimal InsuredAmountValueMin { get; set; }
        public decimal InsuredAmountValueMax { get; set; }
        public int TermTypeId { get; set; }
        public decimal PremiumValue { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public DateTime DateUtc { get; set; }
        public virtual Borrower Taker { get; set; } = null!;
    }
}
