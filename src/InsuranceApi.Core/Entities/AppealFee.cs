using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class AppealFee : IIdentityEntity
    {
        public int AppealFeeId { get; set; }
        public decimal InsuredAmountValueMin { get; set; }
        public decimal InsuredAmountValueMax { get; set; }
        public int TermTypeId { get; set; }
        public decimal PremiumValue { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public DateTime DateUtc { get; set; }
    }
}
