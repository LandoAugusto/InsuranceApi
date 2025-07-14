namespace InsuranceApi.Core.Models
{
    public class CoverageActivityLimitFilterModel
    {
        public int ProductVersionId { get; set; }
        public int CoverageId { get; set; }
        public int ActivityId { get; set; }
        public int ProfileId { get; set; }
        public decimal InsuredAmountValue { get; set; } = 0.0m; 

    }
}
