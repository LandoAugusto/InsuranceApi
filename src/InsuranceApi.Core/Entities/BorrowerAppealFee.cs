using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class BorrowerAppealFee : IIdentityEntity
    {
        public int BorrowerAppealFeeId { get; set; }
        public int BorrowerId { get; set; }
        public int ProductId { get; set; }
        public int CoverageId { get; set; }
        public decimal InsuredAmountValueMin { get; set; }
        public decimal InsuredAmountValueMax { get; set; }
        public int TermTypeId { get; set; }
        public decimal PremiumValue { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public DateTime DateUtc { get; set; }
        public virtual Borrower Borrower { get; set; } = null!;
    }
}
