namespace InsuranceApi.Core.Models
{
    public class BorrowerAppealFeeModel
    {
        public int BorrowerAppealFeeId { get; set; }
        public required BorrowerAppealFeeTakerModel Taker { get; set; }
        public required BorrowerAppealFeeProductModel Product { get; set; }
        public required BorrowerAppealFeeCoverageModel Coverage { get; set; }
        public required BorrowerAppealFeeTermTypeModel TermType { get; set; }
        public decimal InsuredAmountValueMin { get; set; }
        public decimal InsuredAmountValueMax { get; set; }
        public decimal PremiumValue { get; set; }
    }

    public class BorrowerAppealFeeTakerModel
    {
        public int TakerId { get; set; }
        public string? Name { get; set; }
    }

    public class BorrowerAppealFeeTermTypeModel
    {
        public int TermTypeId { get; set; }
        public string? Name { get; set; }
    }

    public class BorrowerAppealFeeProductModel
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
    }

    public class BorrowerAppealFeeCoverageModel
    {
        public int CoverageId { get; set; }
        public string? Name { get; set; }
    }
}