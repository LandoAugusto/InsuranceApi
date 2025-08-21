namespace InsuranceApi.Core.Models
{
    public class AppealFeeModel
    {
        public int AppealFeeId { get; set; }
        public decimal InsuredAmountValueMin { get; set; }
        public decimal InsuredAmountValueMax { get; set; }
        public AppealFeeTermTypeModel TermType { get; set; }
        public decimal PremiumValue { get; set; }
        public int Status { get; set; }
    }

    public class AppealFeeTermTypeModel
    {
        public int TermTypeId { get; set; }
        public string? Name { get; set; }
    }
}
