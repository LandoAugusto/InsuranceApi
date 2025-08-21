namespace InsuranceApi.Core.Models
{
    public class AppealFeeFilterModel
    {
        public decimal? InsuredAmountValueMin { get; set; }
        public decimal? InsuredAmountValueMax { get; set; }
        public decimal? PremiumValue { get; set; }
        public int? TermTypeId { get; set; }
        public int? StatusId { get; set; }
    }
}
