namespace InsuranceApi.Core.Models
{
    public class CalculateValidityFilterModel
    {
        public int ProductVersionId { get; set; }
        public int ProfileId { get; set; }
        public int CalculationTypeId { get; set; }
        public int? CountDays { get; set; }
        public DateTime? StartCoverage { get; set; }
    }
}
