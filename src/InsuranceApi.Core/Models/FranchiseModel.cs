namespace InsuranceApi.Core.Models
{
    public class FranchiseModel
    {
        public int FranchiseId { get; set; }
        public required string Description { get; set; }
        public required string Text { get; set; }
        public int FranchiseTypeId { get; set; }
        public decimal? PercentangeLmi { get; set; }
        public decimal? Percentange { get; set; }
        public decimal? Value { get; set; }
        public int? CountDays { get; set; }
    }
}
